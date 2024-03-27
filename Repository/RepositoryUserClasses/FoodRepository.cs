using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryUserClasses
{
    public  class FoodRepository : RepositoryBase<Food>, IFoodRepository
    {
        public FoodRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public void CreateFood(Food food) => Create(food);

        public void DeleteFood(Food food) => Delete(food);
        

        public IEnumerable<Food> GetAllFoods(bool trackChanges)
            => FindAll(trackChanges).OrderBy(f => f.Name).ToList();


        public Food GetFood(Guid foodId, bool trackChanges)
            => FindByCondition(f => f.Id == foodId, trackChanges)
            .SingleOrDefault();

        public IEnumerable<Food> GetFoodsByCategory(Guid categoryId, bool trackChanges)
            => FindByCondition(f => f.FoodCategories.Any(fc => fc.CategoryId == categoryId), trackChanges).
            ToList();

      
    }
}
