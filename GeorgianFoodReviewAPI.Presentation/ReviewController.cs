using Microsoft.AspNetCore.JsonPatch;
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

    [Route("api/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ReviewController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllReviews()
        {
            var reviews = _service.ReviewService.GetAllReviews(trackChnages: false);
            return Ok(reviews);
        }


        [HttpGet("{id:guid}", Name = "GetReviewById")]
        public IActionResult GetReview(Guid id)
        {
            var review = _service.ReviewService.GetReview(id, trackChnages: false);
            return Ok(review);
        }


        [HttpGet("food/{foodId:Guid}")]
        public IActionResult GetReviewsOfFood(Guid foodId)
        {
            var reviews = _service.ReviewService.GetReviewsOfFood(foodId, trackChanges: false);
            return Ok(reviews);
        }


        [HttpPost]
        public IActionResult CreateReview(Guid reviewerId, Guid FoodId, [FromBody]
                                             ReviewForCreationDto review)
        {
            if (review is null)
                return BadRequest("ReviewForCreationDto is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var reviewCreated = _service.ReviewService.CreateReview(reviewerId, FoodId, review,
                                         trackChanges: false);
            return CreatedAtRoute("GetReviewById", new { reviewerId, FoodId, id = reviewCreated.id },
                                                    reviewCreated);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteReview(Guid id)
        {
            _service.ReviewService.DeleteReview(id, trackChanges: false);

            return NoContent();
        }
        [HttpDelete("DeleteReviewsOfReviewer/{id:guid}")]
        public IActionResult DeleteReviewsOfReviewers(Guid id)
        {
            _service.ReviewService.DeleteReviewsOfReviewer(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateReview(Guid id, [FromBody] ReviewForUpdateDto review)
        {
            _service.ReviewService.UpdateReview(id, review, trackChanges: true);
            return NoContent();
        }
        [HttpPatch("{id:Guid}")]
        public IActionResult PartiallyUpdateReview(Guid id, [FromBody] JsonPatchDocument<ReviewForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("PatchDOc is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var result = _service.ReviewService.GetReviewForPatch(id, trackChanges: true);

            patchDoc.ApplyTo(result.reviewToPatch);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            TryValidateModel(result.reviewToPatch);

            _service.ReviewService.SaveChangesForPatch(result.reviewToPatch, result.reviewEntity);
            return NoContent(); 


        }
    }
}
