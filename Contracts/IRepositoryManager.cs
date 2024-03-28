using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ICategoryRepository Category { get; }
        ICountryRepository Country { get; }
        IFoodRepository Food { get; }
        IReviewRepository Review { get; }
        IReviewerRepository Reviewer { get; }
        IFoodCategoryRepository FoodCategory { get; }
        Task SaveAsync();
    }
}
