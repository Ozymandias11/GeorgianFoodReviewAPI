using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryUserClasses
{
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public void CreateReview(Guid ReviewerId, Guid FoodId, Review review)
        {
            review.RevieweverId = ReviewerId;
            review.FoodId = FoodId;
            Create(review);
        }

        public void DeteleReview(Review review) => Delete(review);
        
            
        


        // we have include redudancies, do not forget to fix
        // 
        public IEnumerable<Review> GetAllReviews(bool trackChanges)
             => FindAll(trackChanges)
            .Include(r => r.Food)
            .OrderBy(r => r.Title).ToList();

        public Review GetReview(Guid reviewId, bool trackChanges)
            => FindByCondition(r => r.id == reviewId, trackChanges)
            .Include(r => r.Food)
            .FirstOrDefault();

        public IEnumerable<Review> GetReviewsOfFood(Guid foodId, bool trackChanges)
            => FindByCondition(r => r.FoodId == foodId, trackChanges)
            .Include(r => r.Food)
            .OrderBy(c => c.rating)
            .ToList();

        public IEnumerable<Review> GetReviewsOfReviewer(Guid reviewerId, bool trackChanges)
            => FindByCondition(r => r.RevieweverId == reviewerId, trackChanges).ToList();
        
    }
}
