using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Clay.Entities;
using IdentityModel;
using IdentityServer;
using IdentityServer4.Events;
using IdentityServer4.Models;
using IdentityServer4.Quickstart.UI;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Clay.IdentityServer.Account.Model
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class RegisterController : OAuthControllerHelper
    {
        private readonly IEmailSender _emailSender;
        private readonly ILogger<RegisterAccountModel> _logger;

        public RegisterController(
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IAuthenticationSchemeProvider schemeProvider,
            IEventService events,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterAccountModel> logger,
            IEmailSender emailSender) : base(interaction,
            clientStore, schemeProvider, events, signInManager, userManager)
        {
            _logger = logger;
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult Index(string returnUrl = null) =>
            View(new RegisterAccountModel() { ReturnUrl = returnUrl });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegisterAccountModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                if (_userManager.Users.Any(u => u.UserName == model.Email))
                {
                    ModelState.AddModelError("", "The user is already registered");
                    return View(model);
                }

                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        null,
                        new { userId = user.Id, code },
                        Request.Scheme);

                    await _emailSender.SendEmailAsync(user.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    var subjectId = Guid.NewGuid().ToString();
                    var claimResult = AddClaims(user, subjectId).Result;
                    if (!claimResult.Succeeded) throw new Exception(claimResult.Errors.First().Description);

                    var request = await _interaction.GetAuthorizationContextAsync(model.ReturnUrl);
                    var loginResult = await CommonLogin(request,
                        new LoginInputModel
                        {
                            Password = model.Password,
                            Username = user.UserName,
                            RememberLogin = false,
                            ReturnUrl = returnUrl
                        });

                    await AddConstents(request, model, subjectId);

                    return loginResult;
                }

                foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private async Task<AuthorizationRequest> AddConstents(AuthorizationRequest request, RegisterAccountModel model, string subjectId)
        {
            if (request == null) throw new Exception("Invalid redirect URL");

            var scopes = request.ScopesRequested;
            if (scopes == null || !scopes.Any())
            {
                throw new Exception(ConsentOptions.MustChooseOneErrorMessage);
            }
            if (ConsentOptions.EnableOfflineAccess == false)
            {
                scopes = scopes.Where(x => x != IdentityServer4.IdentityServerConstants.StandardScopes.OfflineAccess);
            }
            var grantedConsent = new ConsentResponse
            {
                RememberConsent = true,
                ScopesConsented = scopes
            };

            // emit event
            await _events.RaiseAsync(new ConsentGrantedEvent(subjectId,
                request.ClientId,
                request.ScopesRequested,
                grantedConsent.ScopesConsented,
                grantedConsent.RememberConsent));
            await _interaction.GrantConsentAsync(request, grantedConsent);
            return request;
        }

        private async Task<IdentityResult> AddClaims(ApplicationUser user, string subjectId) =>
            await _userManager.AddClaimsAsync(user, new[]
            {
                new Claim(JwtClaimTypes.Subject, subjectId),
                new Claim(JwtClaimTypes.Email, user.Email),
                new Claim(JwtClaimTypes.EmailVerified, "false", ClaimValueTypes.Boolean)
            });
    }
}