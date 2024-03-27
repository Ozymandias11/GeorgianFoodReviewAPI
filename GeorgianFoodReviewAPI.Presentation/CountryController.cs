using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.DtosForPost;
using Shared.DataTransferObjects.DtosForPut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public IActionResult GetCountries()
        {
            var countries = _service.CountryService.GetAllCountries(trackChanges:false);
            return Ok(countries);
        }

        [HttpGet("{id:guid}", Name = "CountryById")]
        public IActionResult GetCountry(Guid id)
        {
            var country = _service.CountryService.GetCountry(id, trackChanges: false);
            return Ok(country);
        }

        [HttpPost]
        public IActionResult CreateCountry([FromBody] CountryForCreationDto country)
        {

            if(country is null)
                return BadRequest("CountryToCreateDto is null");
            

            var createdCountry = _service.CountryService.CreateCountry(country);

            return CreatedAtRoute("CountryById", new { id = createdCountry.Id }, createdCountry);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteCountry(Guid id)
        {
            _service.CountryService.DeleteCountry(id, trackChanges:false);
            return NoContent();
        }

        [HttpPut("{id:Guid}")]
        public IActionResult UpdateCountry(Guid id, [FromBody] CountryForUpdateDto country)
        {
            if (country is null)
                return BadRequest("CountryForUpdateDto is null");

            _service.CountryService.UpdateCountry(id,country, trackChanges:true);
            return NoContent(); 
        }


    }
}
