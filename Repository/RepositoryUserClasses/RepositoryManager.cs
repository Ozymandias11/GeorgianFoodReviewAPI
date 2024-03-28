using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryUserClasses
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;

        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<ICountryRepository> _countryRepository;
        private readonly Lazy<IFoodRepository> _foodRepository;
        private readonly Lazy<IReviewerRepository> _reviewerRepository;
        private readonly Lazy<IReviewRepository> _reviewRepository;
        private readonly Lazy<IFoodCategoryRepository> _foodCategoryRepository;


        // By using lazy classes our repository instances are going to be created 
        // after we access them for the first time
        public RepositoryManager(RepositoryContext repositoryContext)
        {

            _repositoryContext = repositoryContext;

            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(repositoryContext));
            _countryRepository = new Lazy<ICountryRepository>(() => new CountryRepository(repositoryContext));
            _foodRepository = new Lazy<IFoodRepository>(() => new FoodRepository(repositoryContext));
            _reviewRepository = new Lazy<IReviewRepository>(() => new ReviewRepository(repositoryContext));
            _reviewerRepository = new Lazy<IReviewerRepository>(() => new ReveiwerRepository(repositoryContext));
            _foodCategoryRepository = new Lazy<IFoodCategoryRepository>(() => new FoodCategoryRepository(repositoryContext));   


        }

        public ICategoryRepository Category => _categoryRepository.Value;
        public ICountryRepository Country => _countryRepository.Value;
        public IFoodRepository Food => _foodRepository.Value;
        public IReviewRepository Review => _reviewRepository.Value;
        public IReviewerRepository Reviewer => _reviewerRepository.Value;
        public IFoodCategoryRepository FoodCategory => _foodCategoryRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();



    }
}
