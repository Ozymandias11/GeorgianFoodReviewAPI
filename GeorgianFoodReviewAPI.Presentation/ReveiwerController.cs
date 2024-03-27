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
    [Route("api/reviewers")]
    [ApiController]
    public class ReveiwerController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ReveiwerController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllReviewers()
        {
            var reviewers = _service.ReviewerService.GetAllReviewers(trackChanges:false);
            return Ok(reviewers);
        }

        [HttpGet("{id:guid}", Name = "GetReviewerById")]
        public IActionResult GetReviewers(Guid id) 
        {
            var reviewer = _service.ReviewerService.GetReviewer(id, trackChanges:false);
            return Ok(reviewer);    
        }

        [HttpGet("country/{countryId:Guid}")]
        public IActionResult GetReviewersOfCountry(Guid countryId)
        {
            var reviewers = _service.ReviewerService.GetReviewersOfCountry(countryId, trackChanges:false);
            return Ok(reviewers);
        }

        [HttpPost]
        public IActionResult CreateReviewerForCountry(Guid countryId, [FromBody] ReviewerForCreationDto reviewer)
        {
            if (reviewer is null)
                return BadRequest("ReviewerForCreationDto is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createdReviewer = _service.ReviewerService.CreateReviewerForCountry(countryId, reviewer, 
                trackChanges:false);

            return CreatedAtRoute("GetReviewerById", new { countryId, id = createdReviewer.id }, createdReviewer);

        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteReviewer(Guid id)
        {
            _service.ReviewerService.DeleteReviewer(id, trackChanges:false);
            return NoContent();
        }

        [HttpPut("country/{countryId:Guid}/reviewer/{reviewerId:Guid}")]
        public IActionResult UpdateReviewerForCountry(Guid countryId, Guid reviewerId, [FromBody] 
                                                         ReviewerForUpdateDto reviewer)
        {
            if (reviewer is null)
                return BadRequest("ReviewerForUpdateDto is null");

            _service.ReviewerService.UpdateReviewerForCountry(countryId, reviewerId, reviewer, countryTrackChanges: false,
                                                              reviewerTrackChanges: true);
            return NoContent();
        }
        [HttpPatch("country/{countryId:Guid}/reviewer/{reviwerId:Guid}/partial")]
        public IActionResult partiallyUpdateReviewerForCountry(Guid countryId, Guid reviwerId,
            [FromBody] JsonPatchDocument<ReviewerForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("PathDoc is null");
            var result = _service.ReviewerService.GetReviewerForPatch(countryId, reviwerId,
                countryTrackChanges: false, reviewerTrackChanges: true);

            patchDoc.ApplyTo(result.reviewerToPatch);

            _service.ReviewerService.SaveChangesForPatch(result.reviewerToPatch, result.reviwerEntity);

            return NoContent();

        }
    }
}
