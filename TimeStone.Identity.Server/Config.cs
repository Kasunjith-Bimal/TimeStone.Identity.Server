using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeStone.Identity.Server
{
    public class Config
    {
        public static IEnumerable<Client> GetClients()
        {
            return new Client[]
            {
                //new Client
                //{
                //    ClientId ="Angular",
                //    ClientName="Angular Demo",
                //    AllowedGrantTypes = GrantTypes.Implicit,
                //    RedirectUris ={ "http://localhost:4200/auth-callback" },
                //    AllowedScopes={ "openid","email","office","profile"},
                //    PostLogoutRedirectUris = { "http://localhost:4200/login" },
                //    AllowedCorsOrigins = {"http://localhost:4200"},
                //    AllowAccessTokensViaBrowser = true,
                //    AccessTokenLifetime = 3600,
                //    RequireConsent = false,
                //    AlwaysIncludeUserClaimsInIdToken = false,

                //},
                new Client
                {
                    ClientId ="mvc",
                    ClientName="Mvc Demo",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RedirectUris ={ "http://localhost:14534/signin-oidc" },
                    AllowedScopes={ "openid","email","office","profile","API1"},
                    PostLogoutRedirectUris = { "http://localhost:14534/signout-callback-oidc" },
                    ClientSecrets ={new Secret("secret".Sha256()) }
                    
                    //RequireConsent = false,//if enable 3rd party authentication true
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name="office",
                    DisplayName ="office details",
                    UserClaims = {"office_Id"}
                }

            };
        }


        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new ApiResource[]
            {
                new ApiResource("API1","My Demo API")
            };
        }
    }
}
