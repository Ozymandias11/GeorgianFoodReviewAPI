using AutoMapper;
using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<ICountryService> _countryService;
        private readonly Lazy<IFoodService> _foodService;
        private readonly Lazy<IReviewerService> _reviewerService;
        private readonly Lazy<IReviewService> _reviewService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, loggerManager, mapper));
            _countryService = new Lazy<ICountryService>(() => new CountryService(repositoryManager, loggerManager, mapper));
            _foodService = new Lazy<IFoodService>(() => new FoodService(repositoryManager, loggerManager, mapper));
            _reviewerService = new Lazy<IReviewerService>(() => new ReviewerService(repositoryManager, loggerManager, mapper));
            _reviewService = new Lazy<IReviewService>(() => new ReviewService(repositoryManager, loggerManager, mapper));
        }

        public ICategoryService CategoryService => _categoryService.Value;

        public ICountryService CountryService => _countryService.Value;

        public IFoodService FoodService => _foodService.Value;

        public IReviewerService ReviewerService => _reviewerService.Value;

        public IReviewService ReviewService => _reviewService.Value;
    }
}
