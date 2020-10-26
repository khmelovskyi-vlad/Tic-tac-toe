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
                //new IdentityResource("permissions", new string[] { "Permission" }),
                //new IdentityResource("roles", new[] { "role" })
            };
        }
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("api1", "My API")
            };
        //public static IEnumerable<ApiResource> GetApiResources()
        //{
        //    return new List<ApiResource>
        //    {
        //        new ApiResource("api1", "My API")
        //    };
        //}
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
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    //AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequirePkce = false,
                    AllowAccessTokensViaBrowser = true,
                    AlwaysIncludeUserClaimsInIdToken = true,

                    //RedirectUris =           { "https://localhost:5003/callback.html" },
                    //RedirectUris =           { "https://localhost:5003/index.html" },
                    //PostLogoutRedirectUris = { "https://localhost:5003/index.html" },
                    //AllowedCorsOrigins =     { "https://localhost:5003" },
                    //RedirectUris = { "http://localhost:3000" },
                    //RedirectUris = { "http://localhost:3000/signin-oidc" },



                    RedirectUris = { "http://localhost:3000/callback.html" },
                    PostLogoutRedirectUris = { "http://localhost:3000" },
                    AllowedCorsOrigins =     { "http://localhost:3000" },



                    //RedirectUris = { "http://127.0.0.1:5500/dist" },
                    //PostLogoutRedirectUris = { "http://127.0.0.1:5500/dist" },
                    //AllowedCorsOrigins = { "http://127.0.0.1:5500" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        //"roles",
                        "api1",
                        //"permissions"
                    }
                },
                //new Client
                //{
                //    ClientId = "js",
                //    ClientName = "JavaScript Client",
                //    AllowedGrantTypes = GrantTypes.Code,
                //    RequireClientSecret = false,
                
                //    RedirectUris =           { "http://127.0.0.1:5500/dist/callback.html" },
                //    PostLogoutRedirectUris = { "http://127.0.0.1:5500/dist/index.html" },
                //    AllowedCorsOrigins =     { "http://127.0.0.1:5500/dist" },
                
                //    AllowedScopes =
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "api1"
                //    }
                //},
                //new Client
                //{
                //    ClientId = "mvc",
                //    ClientSecrets = { new Secret("secret".Sha256()) },

                //    AllowedGrantTypes = GrantTypes.Code,

                //    RedirectUris = { "https://localhost:44392/signin-oidc" },

                //    PostLogoutRedirectUris = { "https://localhost:44392/signout-callback-oidc" },

                //    AllowOfflineAccess = true,

                //    AllowedScopes = new List<string>
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "api1"
                //    }
                //},
                //new Client
                //{
                //    ClientId = "mvc",
                //    AllowedGrantTypes = GrantTypes.Hybrid,
                //    AllowOfflineAccess = true,
                //    RequirePkce = false,

                //    RequireConsent = false,

                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },
                

                //    RedirectUris = { "https://localhost:44392/signin-oidc" },

                //    PostLogoutRedirectUris = { "https://localhost:44392/signout-callback-oidc" },
                
                //    AllowedScopes = new List<string>
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        //"api1"
                //    }
                //}
            };
        }
    }
}
