using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_Server
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }
        //public static IEnumerable<ApiScope> ApiScopes =>
        //    new List<ApiScope>
        //    {
        //        new ApiScope("api1", "My API")
        //    };
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                //new Client
                //{
                    //ClientId = "mvc",
                    //ClientName = "MVC Client",
                    //AllowedGrantTypes = GrantTypes.Implicit,

                    //// where to redirect to after login
                    //RedirectUris = { "http://localhost:5002/signin-oidc" },

                    //// where to redirect to after logout
                    //PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                    //AllowedScopes = new List<string>
                    //{
                        //IdentityServerConstants.StandardScopes.OpenId,
                        //IdentityServerConstants.StandardScopes.Profile
                    //}
                //},
                new Client
                {
                    ClientId = "mvc",
                    //ClientName = "MVC Client",
                    //AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowOfflineAccess = true,
                    RequirePkce = false,

                    RequireConsent = false,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                
                    // where to redirect to after login
                    RedirectUris = { "https://localhost:44392/signin-oidc" },
                    //RedirectUris = { "http://localhost:44392/signin-oidc" },
                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://localhost:44392/signout-callback-oidc" },
                    //RedirectUris           = { "http://localhost:44392/signin-oidc" },
                    //PostLogoutRedirectUris = { "http://localhost:44392/signout-callback-oidc" },
                
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        //"api1"
                    }
                }
            };
        }
    }
}
