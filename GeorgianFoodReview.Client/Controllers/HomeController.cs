using GeorgianFoodReview.Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<IActionResult> Countries()
        {
            var httpClient = _httpClientFactory.CreateClient("APIClient");

            var response = await httpClient.GetAsync("api/countries").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var countriesString = await response.Content.ReadAsStringAsync();

            var companies = JsonSerializer.Deserialize<List<CountryViewModel>>(countriesString, 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

            return View(countriesString);




        }
    }
}
