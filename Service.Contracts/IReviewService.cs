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
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDto>> GetAllReviewsAsync(ReviewParameters reviewParameters ,bool trackChnages);
        Task<ReviewDto> GetReviewAsync(Guid reviewId, bool trackChnages);
        Task<IEnumerable<ReviewDto>> GetReviewsOfFoodAsync(Guid foodId, bool trackChanges);
        Task<ReviewDto> CreateReviewAsync(Guid reviewerId, Guid foodId,
                                         ReviewForCreationDto review, bool trackChanges);
        Task DeleteReviewAsync(Guid reviewId, bool trackChanges);
        Task DeleteReviewsOfReviewerAsync(Guid reviewerId, bool trackChanges);
        Task UpdateReviewAsync(Guid reviewId, ReviewForUpdateDto review, bool trackChanges);

        Task<(ReviewForUpdateDto reviewToPatch, Review reviewEntity)>
          GetReviewForPatchAsync(Guid reviewId, bool trackChanges);
        Task SaveChangesForPatchAsync(ReviewForUpdateDto reviewToPatch, Review reviewEntity);

    }
}
