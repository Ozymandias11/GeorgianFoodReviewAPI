﻿using GeorgianFoodReviewAPI.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.DtosForPost;
using Shared.DataTransferObjects.DtosForPut;
using Shared.RequestFeatures;

namespace GeorgianFoodReviewAPI.Presentation
{
    [Route("api/countries")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CountryController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        [HttpHead]
        [Authorize]
        public async Task<IActionResult> GetCountries([FromQuery] CountryParameters countryParameters)
        {
            var countries = await _service.CountryService.GetAllCountriesAsync(countryParameters ,trackChanges:false);
            return Ok(countries);
        }

        [HttpGet("{id:guid}", Name = "CountryById")]
        public async Task<IActionResult> GetCountry(Guid id)
        {
            var country = await _service.CountryService.GetCountryAsync(id, trackChanges: false);
            return Ok(country);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCountry([FromBody] CountryForCreationDto country)
        {

            var createdCountry = await _service.CountryService.CreateCountryAsync(country);

            return CreatedAtRoute("CountryById", new { id = createdCountry.Id }, createdCountry);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCountry(Guid id)
        {
            await _service.CountryService.DeleteCountryAsync(id, trackChanges:false);
            return NoContent();
        }

        [HttpPut("{id:Guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCountry(Guid id, [FromBody] CountryForUpdateDto country)
        {
         
            await _service.CountryService.UpdateCountryAsync(id,country, trackChanges:true);
            return NoContent(); 
        }


    }
}
