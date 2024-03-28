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

        public async Task<ReviewDto> CreateReviewAsync(Guid reviewerId, Guid foodId, ReviewForCreationDto review, bool trackChanges)
        {
            var reviewerEntity = await _repository.Reviewer.GetRevieweverAsync(reviewerId, trackChanges);

            if(reviewerEntity is null)
                throw new ReviewerNotFoundException(reviewerId);

            var foodEntity = await _repository.Food.GetFoodAsync(foodId, trackChanges);

            if(foodEntity is null)
                throw new FoodNotFoundException(foodId);

            var reviewEntity = _mapper.Map<Review>(review);

            _repository.Review.CreateReview(reviewerId, foodId, reviewEntity);
            await _repository.SaveAsync();

            var reviewToReturn = _mapper.Map<ReviewDto>(reviewEntity);

            return reviewToReturn;


        }

        public async Task DeleteReviewAsync(Guid reviewId, bool trackChanges)
        {
            var reviewEntity = await _repository.Review.GetReviewAsync(reviewId, trackChanges);

            if(reviewEntity is null)
                throw new ReviewNotFoundException(reviewId);

            _repository.Review.DeteleReview(reviewEntity);
            await _repository.SaveAsync();

        }

        public async Task DeleteReviewsOfReviewerAsync(Guid reviewerId, bool trackChanges)
        {
            var reviewerEntity = _repository.Reviewer.GetRevieweverAsync(reviewerId, trackChanges);

            if (reviewerEntity is null)
                throw new ReviewerNotFoundException(reviewerId);

            var reviewsOfReviewers = await _repository.Review.
                GetReviewsOfReviewerAsync(reviewerId, trackChanges);

            foreach(var review in reviewsOfReviewers)
                _repository.Review.DeteleReview(review);

            await _repository.SaveAsync();

        }

        public async Task<IEnumerable<ReviewDto>> GetAllReviewsAsync(bool trackChnages)
        {
            var reviews = await _repository.Review.GetAllReviewsAsync(trackChnages);
            
            var reviewsDto = _mapper.Map<IEnumerable<ReviewDto>>(reviews);

            return reviewsDto;
        }

        public async Task<ReviewDto> GetReviewAsync(Guid reviewId, bool trackChnages)
        {
            var review = await _repository.Review.GetReviewAsync(reviewId, trackChnages);

            if(review is null)
                throw new ReviewNotFoundException(reviewId);

            var reviewDto = _mapper.Map<ReviewDto>(review);
            return reviewDto;
        }

        public async Task<(ReviewForUpdateDto reviewToPatch, Review reviewEntity)>
            GetReviewForPatchAsync(Guid reviewId, bool trackChanges)
        {
            var reviewEntity = await _repository.Review.GetReviewAsync(reviewId, trackChanges);

            if(reviewEntity is null)
                throw new ReviewNotFoundException(reviewId);

            var reviewToPatch = _mapper.Map<ReviewForUpdateDto>(reviewEntity);
            return (reviewToPatch, reviewEntity);

        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsOfFoodAsync(Guid foodId, bool trackChanges)
        {
            var reviews = await _repository.Review.GetReviewsOfFoodAsync(foodId, trackChanges);
            var reviewDto = _mapper.Map<IEnumerable<ReviewDto>>(reviews);
            return reviewDto;
        }

        public async Task SaveChangesForPatchAsync(ReviewForUpdateDto reviewToPatch, Review reviewEntity)
        {
            _mapper.Map(reviewToPatch, reviewEntity);
            await _repository.SaveAsync();
        }

        public async Task UpdateReviewAsync(Guid reviewId, ReviewForUpdateDto review, bool trackChanges)
        {
            var reviewEntity = await _repository.Review.GetReviewAsync(reviewId, trackChanges);

            if(reviewEntity is null)
                throw new ReviewNotFoundException(reviewId);

            _mapper.Map(review, reviewEntity);
            await _repository.SaveAsync();


        }
    }
}
