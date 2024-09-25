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
            new IdentityResources.Address(),
            new IdentityResource("roles", "User role(s)", new List<string>{"role"}),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            { 
            new ApiScope("georgianfoodreviewapi.scope","GeorgianFoodReview API Scope")
            };

    public static IEnumerable<ApiResource> Apis =>
         new ApiResource[]
         {
             new ApiResource("georgianfoodreviewapi", "GeorgianFoodReview API")
             {
                 Scopes = { "georgianfoodreviewapi.scope" }
             }
         };

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
                    IdentityServerConstants.StandardScopes.Address,
                    "roles",
                    "georgianfoodreviewapi.scope"},
                    ClientSecrets = {new Secret("GeorgianFoodReviewClientSecret".ToSha512())},
                    RequireConsent = true,
                    PostLogoutRedirectUris = new List<string> { "https://localhost:7221/signout-callback-oidc" },
                    RequirePkce = true
                }
            };
}