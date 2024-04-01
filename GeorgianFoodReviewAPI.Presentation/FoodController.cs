using GeorgianFoodReviewAPI.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.DtosForPost;
using Shared.DataTransferObjects.DtosForPut;
using Shared.RequestFeatures;
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
        [Authorize(Roles = "Manager, Administrator")]

        public async Task<IActionResult> GetAllFoods([FromQuery] FoodParameters foodParameters)
        {
            var foods = await _service.FoodService.GetAllFoodsAsync(foodParameters ,trackChanges: false);
            return Ok(foods);
        }

        [HttpGet("{id:guid}", Name = "GetFoodById")]
        [Authorize(Roles = "Manager, Administrator")]
        public async Task<IActionResult> GetFood(Guid id)
        {
            var food = await _service.FoodService.GetFoodAsync(id, trackChanges:false);
            return Ok(food);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(Roles = "Manager, Administrator")]
        public async Task<IActionResult> CreateFood(Guid categoryId, [FromBody] FoodForCreationDto food)
        {
           
            var createdFood = await _service.FoodService.CreateFoodAsync(categoryId, food, trackChanges:false);

            return CreatedAtRoute("GetFoodById",new { categoryId, id = createdFood.id }, createdFood);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteFood(Guid id)
        {
            await _service.FoodService.DeleteFoodAsync(id, trackChanges:false);
            return NoContent();
        }


        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(Roles = "Manager, Administrator")]
        public async Task<IActionResult> UpdateFood(Guid id, [FromBody] FoodForUpdateDto food)
        {

            await _service.FoodService.UpdateFoodAsync(id, food, trackChanges: true);
            return NoContent();

        }


    }
}
