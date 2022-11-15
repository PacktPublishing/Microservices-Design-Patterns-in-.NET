using Duende.IdentityServer.Models;

namespace HealthCare.Auth
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource("roles", "User role(s)", new List<string> { "role" })
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("healthcareApiUser", "HealthCare API User"),
                new ApiScope("healthcareApiClient", "HealthCare API Client "),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
            // m2m client credentials flow client
            new Client
            {
                ClientId = "m2m.client",
                ClientName = "Client Credentials Client",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                AllowedScopes = { "healthcareApiClient" }
            },

            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "interactive",
                ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { "https://localhost:5001/signin-oidc" },
                FrontChannelLogoutUri = "https://localhost:5001/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:5001/signout-callback-oidc" },

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "healthcareApiUser" }
            },
            };
    }
}