using System.Collections.Generic;
using Clay.DAL;
using IdentityServer4;
using IdentityServer4.Models;
using EF = IdentityServer4.EntityFramework.Entities;

namespace IdentityServer
{
    public static class ClientRepositoryExtensions
    {
        public const string DoorLocksApiName = "clayLockApi";
        public static IEnumerable<Client> InitialEntities(this IRepository<EF.Client> repo) =>
            new List<Client>
            {
                // OpenID Connect hybrid flow and client credentials client (MVC)
                new Client
                {
                    ClientId = "clay",
                    ClientName = "Clay OAuth",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    AllowOfflineAccess = true,
                    AllowRememberConsent = true,
                    RedirectUris =           { "http://localhost:3000/index.html" },
                    PostLogoutRedirectUris = { "http://localhost:3000/index.html" },
                    AllowedCorsOrigins =     { "http://localhost:3000" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        DoorLocksApiName
                    }
                }
            };

        public static IEnumerable<ApiResource> InitialEntities(this IRepository<EF.ApiResource> repo)
        {
            return new List<ApiResource>
            {
                new ApiResource(DoorLocksApiName, "Clay Door Locks Api")
            };
        }

        public static IEnumerable<IdentityResource> InitialEntities(this IRepository<EF.IdentityResource> repo)
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }
    }
}