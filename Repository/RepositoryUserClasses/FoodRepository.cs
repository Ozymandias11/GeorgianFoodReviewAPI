using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
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
        

        public async Task<IEnumerable<Food>> GetAllFoodsAsync(bool trackChanges)
            => await FindAll(trackChanges).OrderBy(f => f.Name).ToListAsync();


        public async Task<Food> GetFoodAsync(Guid foodId, bool trackChanges)
            => await FindByCondition(f => f.Id == foodId, trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Food>> GetFoodsByCategoryAsync(Guid categoryId, bool trackChanges)
            => await FindByCondition(f => f.FoodCategories.Any(fc => fc.CategoryId == categoryId), trackChanges).
            ToListAsync();

      
    }
}
