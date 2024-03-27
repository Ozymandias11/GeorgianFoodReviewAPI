using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.DtosForGet;
using Shared.DataTransferObjects.DtosForPost;
using Shared.DataTransferObjects.DtosForPut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ReviewService : IReviewService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ReviewService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

        }

        public ReviewDto CreateReview(Guid reviewerId, Guid foodId, ReviewForCreationDto review, bool trackChanges)
        {
            var reviewerEntity = _repository.Reviewer.GetReviewever(reviewerId, trackChanges);

            if(reviewerEntity is null)
                throw new ReviewerNotFoundException(reviewerId);

            var foodEntity = _repository.Food.GetFood(foodId, trackChanges);

            if(foodEntity is null)
                throw new FoodNotFoundException(foodId);

            var reviewEntity = _mapper.Map<Review>(review);

            _repository.Review.CreateReview(reviewerId, foodId, reviewEntity);
            _repository.Save();

            var reviewToReturn = _mapper.Map<ReviewDto>(reviewEntity);

            return reviewToReturn;


        }

        public void DeleteReview(Guid reviewId, bool trackChanges)
        {
            var reviewEntity = _repository.Review.GetReview(reviewId, trackChanges);

            if(reviewEntity is null)
                throw new ReviewNotFoundException(reviewId);

            _repository.Review.DeteleReview(reviewEntity);
            _repository.Save();

        }

        public void DeleteReviewsOfReviewer(Guid reviewerId, bool trackChanges)
        {
            var reviewerEntity = _repository.Reviewer.GetReviewever(reviewerId, trackChanges);

            if (reviewerEntity is null)
                throw new ReviewerNotFoundException(reviewerId);

            var reviewsOfReviewers = _repository.Review.GetReviewsOfReviewer(reviewerId, trackChanges);

            foreach(var review in reviewsOfReviewers)
                _repository.Review.DeteleReview(review);

            _repository.Save();

        }

        public IEnumerable<ReviewDto> GetAllReviews(bool trackChnages)
        {
            var reviews = _repository.Review.GetAllReviews(trackChnages);
            
            var reviewsDto = _mapper.Map<IEnumerable<ReviewDto>>(reviews);

            return reviewsDto;
        }

        public ReviewDto GetReview(Guid reviewId, bool trackChnages)
        {
            var review = _repository.Review.GetReview(reviewId, trackChnages);
            if(review is null)
            {
                throw new ReviewNotFoundException(reviewId);
            }
                
            
            var reviewDto = _mapper.Map<ReviewDto>(review);
            return reviewDto;
        }

        public (ReviewForUpdateDto reviewToPatch, Review reviewEntity) GetReviewForPatch(Guid reviewId, bool trackChanges)
        {
            var reviewEntity = _repository.Review.GetReview(reviewId, trackChanges);

            if(reviewEntity is null)
                throw new ReviewNotFoundException(reviewId);

            var reviewToPatch = _mapper.Map<ReviewForUpdateDto>(reviewEntity);
            return (reviewToPatch, reviewEntity);

        }

        public IEnumerable<ReviewDto> GetReviewsOfFood(Guid foodId, bool trackChanges)
        {
            var reviews = _repository.Review.GetReviewsOfFood(foodId, trackChanges);
            var reviewDto = _mapper.Map<IEnumerable<ReviewDto>>(reviews);
            return reviewDto;
        }

        public void SaveChangesForPatch(ReviewForUpdateDto reviewToPatch, Review reviewEntity)
        {
            _mapper.Map(reviewToPatch, reviewEntity);
            _repository.Save();
        }

        public void UpdateReview(Guid reviewId, ReviewForUpdateDto review, bool trackChanges)
        {
            var reviewEntity = _repository.Review.GetReview(reviewId, trackChanges);

            if(reviewEntity is null)
                throw new ReviewNotFoundException(reviewId);

            _mapper.Map(review, reviewEntity);
            _repository.Save();


        }
    }
}
