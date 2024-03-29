using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllReviewsAsync(ReviewParameters reviewParameters ,bool trackChanges);
        Task<Review> GetReviewAsync(Guid reviewId, bool trackChanges);
        Task<IEnumerable<Review>> GetReviewsOfFoodAsync(Guid foodId, bool trackChanges);
        Task<IEnumerable<Review>> GetReviewsOfReviewerAsync(Guid reviewerId, bool trackChanges);
        void CreateReview(Guid ReviewerId, Guid FoodId, Review review);
        void DeteleReview(Review review);
    }
}
