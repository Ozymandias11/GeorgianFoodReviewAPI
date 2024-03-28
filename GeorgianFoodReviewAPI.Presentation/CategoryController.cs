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

    [Route("api/categories")]
    [ApiController]
    public  class CategoryController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CategoryController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            
            var categories = _service.CategoryService.GetAllCategories(trackChanges: false);
            return Ok(categories);
            
        }
        [HttpGet("{id:guid}", Name = "CategoryById")]
        public IActionResult GetCategory(Guid id)
        {
            var category = _service.CategoryService.GetCategory(id, trackChanges:false);
            return Ok(category);
        }
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryToCreateDto category)
        {
            if (category == null)
                return BadRequest("CategoryToCreateDto is null");

            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
              
            

            var createdCategory = _service.CategoryService.CreateCategory(category);

            return CreatedAtRoute("CategoryById", new { id = createdCategory.CategoryId},createdCategory);

        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteCategory(Guid id)
        {
            _service.CategoryService.DeleteCategory(id, trackChanges:false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateCategory(Guid id, [FromBody] CategoryForUpdateDto category)
        {

            if (category is null)
                return BadRequest("CategoryForUpdate Dto is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _service.CategoryService.UpdateCatgeory(id, category, trackChanges:true);
            return NoContent();
        }


    }
}
