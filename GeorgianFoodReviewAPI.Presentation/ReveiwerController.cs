using GeorgianFoodReviewAPI.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
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
    [Route("api/reviewers")]
    [ApiController]
    [Authorize(Roles = "Manager, Administrator")]
    public class ReveiwerController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ReveiwerController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Manager, Administrator")]
        public async Task<IActionResult> GetAllReviewers([FromQuery] ReviewerParameters reviewerParameters)
        {
            var reviewers = await _service.ReviewerService.GetAllReviewersAsync(reviewerParameters, trackChanges:false);
            return Ok(reviewers);
        }

        [HttpGet("{id:guid}", Name = "GetReviewerById")]
        public async Task<IActionResult> GetReviewers(Guid id) 
        {
            var reviewer = await _service.ReviewerService.GetReviewerAsync(id, trackChanges:false);
            return Ok(reviewer);    
        }

        [HttpGet("country/{countryId:Guid}")]
        public async Task<IActionResult> GetReviewersOfCountry(Guid countryId)
        {
            var reviewers = await _service.ReviewerService.GetReviewersOfCountryAsync(countryId, trackChanges:false);
            return Ok(reviewers);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateReviewerForCountry(Guid countryId, [FromBody] ReviewerForCreationDto reviewer)
        {
           
            var createdReviewer = await _service.ReviewerService.CreateReviewerForCountryAsync(countryId, reviewer, 
                trackChanges:false);

            return CreatedAtRoute("GetReviewerById", new { countryId, id = createdReviewer.id }, createdReviewer);

        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteReviewer(Guid id)
        {
            await _service.ReviewerService.DeleteReviewerAsync(id, trackChanges:false);
            return NoContent();
        }

        [HttpPut("country/{countryId:Guid}/reviewer/{reviewerId:Guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateReviewerForCountry(Guid countryId, Guid reviewerId, [FromBody] 
                                                         ReviewerForUpdateDto reviewer)
        {
            
            await _service.ReviewerService.UpdateReviewerForCountryAsync(countryId, reviewerId, reviewer, countryTrackChanges: false,
                                                              reviewerTrackChanges: true);
            return NoContent();
        }
        [HttpPatch("country/{countryId:Guid}/reviewer/{reviwerId:Guid}/partial")]
        public async Task<IActionResult> partiallyUpdateReviewerForCountry(Guid countryId, Guid reviwerId,
            [FromBody] JsonPatchDocument<ReviewerForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("PathDoc is null");

            var result = await _service.ReviewerService.GetReviewerForPatchAsync(countryId, reviwerId,
                countryTrackChanges: false, reviewerTrackChanges: true);

            patchDoc.ApplyTo(result.reviewerToPatch);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            TryValidateModel(result.reviewerToPatch);

            await _service.ReviewerService.SaveChangesForPatchAsync(result.reviewerToPatch,
                result.reviwerEntity);

            return NoContent();

        }
    }
}
