using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryUserClasses
{
    public class FoodCategoryRepository : RepositoryBase<FoodCategory>, IFoodCategoryRepository
    {
        public FoodCategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }
        public void CreateFoodCategory(Food food, Category category)
        {
            var foodCategory = new FoodCategory()
            {
                FoodId = food.Id,
                CategoryId = category.CategoryId
            };

            Create(foodCategory);
        }
    }
}
