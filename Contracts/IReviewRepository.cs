using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IReviewRepository
    {
        IEnumerable<Review> GetAllReviews(bool trackChanges);
        Review GetReview(Guid reviewId, bool trackChanges);
        IEnumerable<Review> GetReviewsOfFood(Guid foodId, bool trackChanges);
        IEnumerable<Review> GetReviewsOfReviewer(Guid reviewerId, bool trackChanges);
        void CreateReview(Guid ReviewerId, Guid FoodId, Review review);
        void DeteleReview(Review review);
    }
}
