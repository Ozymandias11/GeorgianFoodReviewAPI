using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Globalization;

namespace GeorgianFoodReview.Client.Handler
{
    // DelegatingUser allows us to delegate the processing of HTTP response messages to another handler
    public class BearerTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;

        public BearerTokenHandler(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory)
        {
            _contextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessToken = await GetAccessToken();

            if (string.IsNullOrEmpty(accessToken))
            {
                //attaching access token to request
                request.SetBearerToken(accessToken);
            }

            return await base.SendAsync(request, cancellationToken);

        }

        public async Task<string> GetAccessToken()
        {
            // checking if token is aleady expired or near expiration

            var expiresAtToken = await _contextAccessor.HttpContext.GetTokenAsync("expires_at");

            var expiresAtDateTimeOffset = DateTimeOffset.Parse(expiresAtToken, CultureInfo.InvariantCulture);

            if ((expiresAtDateTimeOffset.AddSeconds(-60)).ToUniversalTime() > DateTime.UtcNow)
            {
                return await _contextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            }

            var refreshResponse = await GetRefreshResponseFromIDP();


            var updatedTokens = GetUpdatedTokens(refreshResponse);


            var currentAuthenticateResult = await
                 _contextAccessor.HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);


            // if a new token is obtained, it updates the authentication tokens in user's session

            currentAuthenticateResult.Properties.StoreTokens(updatedTokens);


            await _contextAccessor.HttpContext.SignInAsync(
                      CookieAuthenticationDefaults.AuthenticationScheme,
                      currentAuthenticateResult.Principal,
                      currentAuthenticateResult.Properties
                );


            return refreshResponse.AccessToken;

        }


        // following method requests new access token using the refresh token, which returns new tokens
        private async Task<TokenResponse> GetRefreshResponseFromIDP()
        {
            var idpClient = _httpClientFactory.CreateClient("IDPClient");

            var metaDataResponse = await idpClient.GetDiscoveryDocumentAsync();

            var refreshToken = await _contextAccessor.HttpContext
                .GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

            var refreshResponse = await idpClient.RequestRefreshTokenAsync(
                    new RefreshTokenRequest
                    {
                        Address = metaDataResponse.TokenEndpoint,
                        ClientId = "georgianfoodreviewclient",
                        ClientSecret = "GeorgianFoodReviewClientSecret",
                        RefreshToken = refreshToken
                    }
                );

            return refreshResponse;


        }

        // after refresh token exchange the following method returns a list of updated AUT tokens (Id token, access token,
        // refresh token)
        private List<AuthenticationToken> GetUpdatedTokens(TokenResponse refreshResponse)
        {
            return
            [
                    new AuthenticationToken
                    {
                        Name = OpenIdConnectParameterNames.IdToken,
                        Value = refreshResponse.IdentityToken
                    },
                    new AuthenticationToken
                    {
                        Name = OpenIdConnectParameterNames.AccessToken,
                        Value = refreshResponse.AccessToken
                    },
                    new AuthenticationToken
                    {
                        Name = OpenIdConnectParameterNames.RefreshToken,
                        Value = refreshResponse.RefreshToken
                    },
                    new AuthenticationToken
                    {
                        Name = "expires_at",
                        Value = DateTime.UtcNow.AddSeconds(refreshResponse.ExpiresIn)
                               .ToString("o", CultureInfo.InvariantCulture)
                    }
                ];
            }


    }

}

        