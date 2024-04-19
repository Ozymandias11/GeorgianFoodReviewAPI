using GeorgianFoodReviewAPI.Presentation;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xunit
{
    public  class CountryControllerTest
    {
        private readonly CountryController _controller;
        private readonly ICountryService _service;

        public CountryControllerTest()
        {
            _service = new CountryServiceFake();
            _controller = new CountryController(_service);

        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var okResult = _controller.Get();

        }


    }
}
