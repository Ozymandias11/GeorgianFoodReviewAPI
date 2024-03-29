using GeorgianFoodReviewAPI.Presentation.ActionFilters;
using Microsoft.AspNetCore.JsonPatch;
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

    [Route("api/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ReviewController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews([FromQuery] ReviewParameters reviewParameters)
        {
            var reviews = await _service.ReviewService.GetAllReviewsAsync(reviewParameters, trackChnages: false);
            return Ok(reviews);
        }


        [HttpGet("{id:guid}", Name = "GetReviewById")]
        public async Task<IActionResult> GetReview(Guid id)
        {
            var review = await _service.ReviewService.GetReviewAsync(id, trackChnages: false);
            return Ok(review);
        }


        [HttpGet("food/{foodId:Guid}")]
        public async Task<IActionResult> GetReviewsOfFood(Guid foodId)
        {
            var reviews = await _service.ReviewService.GetReviewsOfFoodAsync(foodId, trackChanges: false);
            return Ok(reviews);
        }


        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateReview(Guid reviewerId, Guid FoodId, [FromBody]
                                             ReviewForCreationDto review)
        {

            var reviewCreated = await _service.ReviewService.CreateReviewAsync(reviewerId, FoodId, review,
                                         trackChanges: false);
            return CreatedAtRoute("GetReviewById", new { reviewerId, FoodId, id = reviewCreated.id },
                                                    reviewCreated);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteReview(Guid id)
        {
            await _service.ReviewService.DeleteReviewAsync(id, trackChanges: false);

            return NoContent();
        }   
        [HttpDelete("DeleteReviewsOfReviewer/{id:guid}")]
        public async Task<IActionResult> DeleteReviewsOfReviewers(Guid id)
        {
            await _service.ReviewService.DeleteReviewsOfReviewerAsync(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateReview(Guid id, [FromBody] ReviewForUpdateDto review)
        {
            await _service.ReviewService.UpdateReviewAsync(id, review, trackChanges: true);
            return NoContent();
        }
        [HttpPatch("{id:Guid}")]
        public async Task<IActionResult> PartiallyUpdateReview(Guid id, [FromBody] JsonPatchDocument<ReviewForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("PatchDOc is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var result = await _service.ReviewService.GetReviewForPatchAsync(id, trackChanges: true);

            patchDoc.ApplyTo(result.reviewToPatch);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            TryValidateModel(result.reviewToPatch);

            await _service.ReviewService.SaveChangesForPatchAsync(result.reviewToPatch, result.reviewEntity);
            return NoContent(); 


        }
    }
}
