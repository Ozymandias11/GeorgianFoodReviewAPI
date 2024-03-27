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
    public interface IReviewService
    {
        IEnumerable<ReviewDto> GetAllReviews(bool trackChnages);
        ReviewDto GetReview(Guid reviewId, bool trackChnages);
        IEnumerable<ReviewDto> GetReviewsOfFood(Guid foodId, bool trackChanges);
        ReviewDto CreateReview(Guid reviewerId, Guid foodId,
                                         ReviewForCreationDto review, bool trackChanges);
        void DeleteReview(Guid reviewId, bool trackChanges);
        void DeleteReviewsOfReviewer(Guid reviewerId, bool trackChanges);
        void UpdateReview(Guid reviewId, ReviewForUpdateDto review, bool trackChanges);

        (ReviewForUpdateDto reviewToPatch, Review reviewEntity)
          GetReviewForPatch(Guid reviewId, bool trackChanges);
        void SaveChangesForPatch(ReviewForUpdateDto reviewToPatch, Review reviewEntity);

    }
}
