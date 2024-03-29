using Entities.Models;
using Shared.DataTransferObjects.DtosForGet;
using Shared.DataTransferObjects.DtosForPost;
using Shared.DataTransferObjects.DtosForPut;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IReviewerService
    {
        Task<IEnumerable<ReviewerDto>> GetAllReviewersAsync(ReviewerParameters reviewerParameters ,bool trackChanges);
        Task<ReviewerDto> GetReviewerAsync(Guid id, bool trackChanges);
        Task<IEnumerable<ReviewerDto>> GetReviewersOfCountryAsync(Guid countryId, bool trackChanges);
        Task<ReviewerDto> CreateReviewerForCountryAsync(Guid countryId, ReviewerForCreationDto reviewer, bool trackChanges);
        Task DeleteReviewerAsync(Guid reviewerId, bool trackChanges);
        Task UpdateReviewerForCountryAsync(Guid countryId, Guid ReviewerId, ReviewerForUpdateDto reviewer,
                                             bool countryTrackChanges, bool reviewerTrackChanges);

        Task<(ReviewerForUpdateDto reviewerToPatch, Reviewer reviwerEntity)>
            GetReviewerForPatchAsync(Guid countryId, Guid reviewerId,
            bool countryTrackChanges, bool reviewerTrackChanges);
        Task SaveChangesForPatchAsync(ReviewerForUpdateDto reviewerToPatch, Reviewer reviewEntity);

    }
}
