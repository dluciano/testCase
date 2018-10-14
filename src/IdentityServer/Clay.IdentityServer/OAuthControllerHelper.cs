// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Clay.Entities;
using IdentityServer4.Events;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using IdentityModel;

namespace IdentityServer4.Quickstart.UI
{
    public abstract class OAuthControllerHelper : Controller
    {
        protected readonly IIdentityServerInteractionService _interaction;
        protected readonly IClientStore _clientStore;
        protected readonly IAuthenticationSchemeProvider _schemeProvider;
        protected readonly IEventService _events;
        protected readonly SignInManager<ApplicationUser> _signInManager;
        protected readonly UserManager<ApplicationUser> _userManager;

        public OAuthControllerHelper(
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IAuthenticationSchemeProvider schemeProvider,
            IEventService events,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _interaction = interaction;
            _clientStore = clientStore;
            _schemeProvider = schemeProvider;
            _events = events;
            _signInManager = signInManager;
            this._userManager = userManager;
        }

        protected async Task<IActionResult> CommonLogin(AuthorizationRequest context, LoginInputModel model)
        {
            var resultLogin =
                await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberLogin, true);
            if (resultLogin.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                var claims = await _userManager.GetClaimsAsync(user);
                var subjectClaim = claims.First(c => c.Type == JwtClaimTypes.Subject);
                await _events.RaiseAsync(new UserLoginSuccessEvent(user.UserName, subjectClaim.Value, user.UserName));

                // only set explicit expiration here if user chooses "remember me". 
                // otherwise we rely upon expiration configured in cookie middleware.
                AuthenticationProperties props = null;
                if (AccountOptions.AllowRememberLogin && model.RememberLogin)
                {
                    props = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.Add(AccountOptions.RememberMeLoginDuration)
                    };
                };
                // issue authentication cookie with subject ID and username
                await HttpContext.SignInAsync(subjectClaim.Value, user.UserName, props, claims.ToArray());

                if (context != null)
                {
                    if (await _clientStore.IsPkceClientAsync(context.ClientId))
                    {
                        // if the client is PKCE then we assume it's native, so this change in how to
                        // return the response is for better UX for the end user.
                        return View("Redirect", new RedirectViewModel { RedirectUrl = model.ReturnUrl });
                    }

                    // we can trust model.ReturnUrl since GetAuthorizationContextAsync returned non-null
                    return Redirect(model.ReturnUrl);
                }

                // request for a local page
                if (Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                if (string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return Redirect("~/");
                }
                else
                {
                    // user might have clicked on a malicious link - should be logged
                    throw new Exception("invalid return URL");
                }
            }

            await _events.RaiseAsync(new UserLoginFailureEvent(model.Username, "invalid credentials"));
            ModelState.AddModelError("", AccountOptions.InvalidCredentialsErrorMessage);
            return View(await BuildLoginViewModelAsync(model));
        }

        /*****************************************/
        /* helper APIs for the AccountController */
        /*****************************************/
        protected async Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl)
        {
            var context = await _interaction.GetAuthorizationContextAsync(returnUrl);
            if (context?.IdP != null)
            {
                // this is meant to short circuit the UI and only trigger the one external IdP
                return new LoginViewModel
                {
                    EnableLocalLogin = false,
                    ReturnUrl = returnUrl,
                    Username = context?.LoginHint,
                    ExternalProviders = new ExternalProvider[] { new ExternalProvider { AuthenticationScheme = context.IdP } }
                };
            }

            var schemes = await _schemeProvider.GetAllSchemesAsync();

            var providers = schemes
                .Where(x => x.DisplayName != null ||
                            (x.Name.Equals(AccountOptions.WindowsAuthenticationSchemeName, StringComparison.OrdinalIgnoreCase))
                )
                .Select(x => new ExternalProvider
                {
                    DisplayName = x.DisplayName,
                    AuthenticationScheme = x.Name
                }).ToList();

            var allowLocal = true;
            if (context?.ClientId != null)
            {
                var client = await _clientStore.FindEnabledClientByIdAsync(context.ClientId);
                if (client != null)
                {
                    allowLocal = client.EnableLocalLogin;

                    if (client.IdentityProviderRestrictions != null && client.IdentityProviderRestrictions.Any())
                    {
                        providers = providers.Where(provider => client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme)).ToList();
                    }
                }
            }

            return new LoginViewModel
            {
                AllowRememberLogin = AccountOptions.AllowRememberLogin,
                EnableLocalLogin = allowLocal && AccountOptions.AllowLocalLogin,
                ReturnUrl = returnUrl,
                Username = context?.LoginHint,
                ExternalProviders = providers.ToArray()
            };
        }

        protected async Task<LoginViewModel> BuildLoginViewModelAsync(LoginInputModel model)
        {
            var vm = await BuildLoginViewModelAsync(model.ReturnUrl);
            vm.Username = model.Username;
            vm.RememberLogin = model.RememberLogin;
            return vm;
        }
    }
}