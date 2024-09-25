using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace GeorgianFoodReview.Client.Handler
{
    // DelegatingUser allows us to delegate the processing of HTTP response messages to another handler
    public class BearerTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public BearerTokenHandler(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessToken = await _contextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);



            if (string.IsNullOrEmpty(accessToken))
            {
                //attaching access token to request
                request.SetBearerToken(accessToken);
            }

            return await base.SendAsync(request, cancellationToken);

        }





    }
}
