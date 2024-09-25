using GeorgianFoodReview.Client.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Diagnostics;
using System.Security.Claims;
using System.Text.Json;

namespace GeorgianFoodReview.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Countries()
        {
            var httpClient = _httpClientFactory.CreateClient("APIClient");

            var response = await httpClient.GetAsync("/api/countries").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var countriesString = await response.Content.ReadAsStringAsync();

            var companies = JsonSerializer.Deserialize<List<CountryViewModel>>(countriesString, 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

            return View(countriesString);




        }
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Privacy()
        {
            var idpClient = _httpClientFactory.CreateClient("IDPClient");

            //following contains /userinfo endpoint's address
            var metaDataResponse = await idpClient.GetDiscoveryDocumentAsync();

            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            var response = await idpClient.GetUserInfoAsync(new UserInfoRequest
            {
                Address = metaDataResponse.UserInfoEndpoint,
                Token = accessToken
            });


            if (response.IsError)
            {
                throw new Exception("Problem with fetching data from the UserInfo endpoint", response.Exception);
            }

            var addressClaim = response.Claims.FirstOrDefault(c => c.Type.Equals("address"));

            User.AddIdentity(new ClaimsIdentity(new List<Claim>
            {
                new Claim(addressClaim.Type.ToString(), addressClaim.Value.ToString()) 
            
            }));

            return View();

            


        
       



        }
    }
}
