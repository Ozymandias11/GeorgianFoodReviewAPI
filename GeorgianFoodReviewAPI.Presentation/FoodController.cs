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
        public async Task<IActionResult> GetAllFoods()
        {
            var foods = await _service.FoodService.GetAllFoodsAsync(trackChanges: false);
            return Ok(foods);
        }

        [HttpGet("{id:guid}", Name = "GetFoodById")]
        public async Task<IActionResult> GetFood(Guid id)
        {
            var food = await _service.FoodService.GetFoodAsync(id, trackChanges:false);
            return Ok(food);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFood(Guid categoryId, [FromBody] FoodForCreationDto food)
        {
            if (food is null)
                return BadRequest("FoodForCreationDto is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createdFood = await _service.FoodService.CreateFoodAsync(categoryId, food, trackChanges:false);

            return CreatedAtRoute("GetFoodById",new { categoryId, id = createdFood.id }, createdFood);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteFood(Guid id)
        {
            await _service.FoodService.DeleteFoodAsync(id, trackChanges:false);
            return NoContent();
        }


        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateFood(Guid id, [FromBody] FoodForUpdateDto food)
        {

            if (food is null)
                return BadRequest("FoodForUpdateDto is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.FoodService.UpdateFoodAsync(id, food, trackChanges: true);
            return NoContent();
        }


    }
}
