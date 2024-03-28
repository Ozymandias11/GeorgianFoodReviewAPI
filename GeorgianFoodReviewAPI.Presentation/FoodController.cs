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
    [Route("api/foods")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IServiceManager _service;
        public FoodController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllFoods()
        {
            var foods = _service.FoodService.GetAllFoods(trackChanges: false);
            return Ok(foods);
        }

        [HttpGet("{id:guid}", Name = "GetFoodById")]
        public IActionResult GetFood(Guid id)
        {
            var food = _service.FoodService.GetFood(id, trackChanges:false);
            return Ok(food);
        }

        [HttpPost]
        public IActionResult CreateFood(Guid categoryId, [FromBody] FoodForCreationDto food)
        {
            if (food is null)
                return BadRequest("FoodForCreationDto is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createdFood = _service.FoodService.CreateFood(categoryId, food, trackChanges:false);

            return CreatedAtRoute("GetFoodById",new { categoryId, id = createdFood.id }, createdFood);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteFood(Guid id)
        {
            _service.FoodService.DeleteFood(id, trackChanges:false);
            return NoContent();
        }


        [HttpPut("{id:guid}")]
        public IActionResult UpdateFood(Guid id, [FromBody] FoodForUpdateDto food)
        {

            if (food is null)
                return BadRequest("FoodForUpdateDto is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _service.FoodService.UpdateFood(id, food, trackChanges: true);
            return NoContent();
        }


    }
}
