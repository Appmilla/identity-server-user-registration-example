using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdentityServerHost;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            {
                new ApiScope(name: "api1", displayName: "MyAPI"),
                new ApiScope("scope1"),
                new ApiScope("scope2"),
            };

    public static IEnumerable<Client> Clients =>
        new Client[] 
            {
                new Client
                {
                    // Called by Console_Client app
                    ClientId = "api_client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1" }
                },                                     
                new Client
                {
                    // Called by interactive ASP.NET Core WebClient App
                    ClientId = "web",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,
            
                    // where to redirect to after login
                    RedirectUris = { "https://localhost:5002/signin-oidc" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },               
                new Client
                {
                    // Called by WebAuthenticatorDemo Xamarin app
                    ClientId = "interactive.confidential.hybrid",
                    ClientName = "Interactive client (OIDC Hybrid Flow)",

                    RedirectUris = { "io.identitymodel.native://callback" },
                    PostLogoutRedirectUris = { "io.identitymodel.native://callback" },

                    ClientSecrets = { new Secret("secret".Sha256()) },
                    RequirePkce = false,
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                   
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "api1"
                    },

                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.ReUse,
                    RefreshTokenExpiration = TokenExpiration.Sliding
                },
                new Client
                {
                    // Called by WebAuthenticatorDemo-OIDICClient Xamarin app
                    ClientId = "pkce_client",
                    ClientName = "Mobile PKCE client",

                    RedirectUris = { "io.identitymodel.native://callback" },
                    PostLogoutRedirectUris = { "io.identitymodel.native://callback" },
                    
                    RequireClientSecret = false,
                    RequirePkce = true,
                    AllowPlainTextPkce = false,
                    AllowedGrantTypes = GrantTypes.Code,
                   
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "api1"
                    },

                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.ReUse,
                    RefreshTokenExpiration = TokenExpiration.Sliding
                },
                new Client
                {
                    // Called by NetCoreConsole client app
                    ClientId = "native.code",
                    ClientName = "Native Client (Code with PKCE)",

                    RedirectUris = { "http://127.0.0.1:45656" },
                    PostLogoutRedirectUris = { "http://127.0.0.1:45656" },

                    RequireClientSecret = false,

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    AllowPlainTextPkce = false,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "api1"
                    },

                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.ReUse,
                    RefreshTokenExpiration = TokenExpiration.Sliding
                 }
            };
}