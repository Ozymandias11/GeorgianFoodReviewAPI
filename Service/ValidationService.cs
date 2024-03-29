using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ValidationService
    {
        private readonly IRepositoryManager _repository;
        public ValidationService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<Category> GetCategoryAndCheckIfItExists(Guid id, bool trackChanges)
        {
            var category = await _repository.Category.GetCategoryAsync(id, trackChanges);

            if (category is null)
                throw new CategoryNotFoundException(id);

            return category;

        }

        public async Task<Country> GetCountryAndCheckItIfExists(Guid id, bool trackChanges)
        {
            var country = await _repository.Country.GetCountryAsync(id, trackChanges);

            if (country is null)
                throw new CountryNotFoundException(id);

            return country;
        }

        public async Task<Food> GetFoodAndCheckIfItExists(Guid id, bool trackChanges)
        {
            var food = await _repository.Food.GetFoodAsync(id, trackChanges);

            if (food is null)
                throw new FoodNotFoundException(id);

            return food;
        }

        public async Task<Reviewer> GetReviewerAndCheckIfItExists(Guid id, bool trackChanges)
        {
            var reviewer = await _repository.Reviewer.GetRevieweverAsync(id, trackChanges);

            if (reviewer is null)
                throw new ReviewerNotFoundException(id);

            return reviewer;

        }

        public async Task<Review> GetReviewAndCheckIfItExists(Guid id, bool trackChanges)
        {
            var review = await _repository.Review.GetReviewAsync(id, trackChanges);

            if(review is null)
                throw new ReviewNotFoundException(id);

            return review;
        }

    }
}
