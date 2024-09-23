using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace GeorgianFoodReview.IDP;

public static class Config
{
    public static IEnumerable<IdentityResource> Ids =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Address()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            { };

    public static IEnumerable<ApiResource> Apis =>
         new ApiResource[]
         { };

    public static IEnumerable<Client> Clients =>
        new Client[] 
            {
                new Client
                {
                    ClientName = "GeorgianFoodReviewClient",
                    ClientId = "georgianfoodreviewclient",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string>{ "https://localhost:7221/signin-oidc" },
                    AllowedScopes = {IdentityServerConstants.StandardScopes.OpenId, 
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Address},
                    ClientSecrets = {new Secret("GeorgianFoodReviewClientSecret".ToSha512())},
                    RequireConsent = true,
                    PostLogoutRedirectUris = new List<string> { "https://localhost:7221/signout-callback-oidc" },
                    RequirePkce = true
                }
            };
}