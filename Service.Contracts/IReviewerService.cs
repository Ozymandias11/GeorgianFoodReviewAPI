using Entities.Models;
using Shared.DataTransferObjects.DtosForGet;
using Shared.DataTransferObjects.DtosForPost;
using Shared.DataTransferObjects.DtosForPut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IReviewerService
    {
        IEnumerable<ReviewerDto> GetAllReviewers(bool trackChanges);
        ReviewerDto GetReviewer(Guid id, bool trackChanges);
        IEnumerable<ReviewerDto> GetReviewersOfCountry(Guid countryId, bool trackChanges);
        ReviewerDto CreateReviewerForCountry(Guid countryId, ReviewerForCreationDto reviewer, bool trackChanges);
        void DeleteReviewer(Guid reviewerId, bool trackChanges);
        void UpdateReviewerForCountry(Guid countryId, Guid ReviewerId, ReviewerForUpdateDto reviewer,
                                             bool countryTrackChanges, bool reviewerTrackChanges);

        (ReviewerForUpdateDto reviewerToPatch, Reviewer reviwerEntity)
            GetReviewerForPatch(Guid countryId, Guid reviewerId,
            bool countryTrackChanges, bool reviewerTrackChanges);
        void SaveChangesForPatch(ReviewerForUpdateDto reviewerToPatch, Reviewer reviewEntity);

    }
}
