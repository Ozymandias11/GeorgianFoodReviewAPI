using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        ICategoryService CategoryService { get; }
        ICountryService CountryService { get; }
        IFoodService FoodService { get; }
        IReviewerService ReviewerService { get; }
        IReviewService ReviewService { get; }
    }
}
