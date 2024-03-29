using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
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
        
        public async Task<IEnumerable<Review>> GetAllReviewsAsync(ReviewParameters reviewParameters, bool trackChanges)
             => await FindAll(trackChanges)
            .Include(r => r.Food)
            .OrderBy(r => r.Title)
            .Skip((reviewParameters.PageNumber - 1) * reviewParameters.PageSize)
            .Take(reviewParameters.PageSize)
            .ToListAsync();

        public async Task<Review> GetReviewAsync(Guid reviewId, bool trackChanges)
            => await FindByCondition(r => r.id == reviewId, trackChanges)
            .Include(r => r.Food)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<Review>> GetReviewsOfFoodAsync(Guid foodId, bool trackChanges)
            => await FindByCondition(r => r.FoodId == foodId, trackChanges)
            .Include(r => r.Food)
            .OrderBy(c => c.rating)
            .ToListAsync();

        public async Task<IEnumerable<Review>> GetReviewsOfReviewerAsync(Guid reviewerId, bool trackChanges)
            => await FindByCondition(r => r.RevieweverId == reviewerId, trackChanges).ToListAsync();
        
    }
}
