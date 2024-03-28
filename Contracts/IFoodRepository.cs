using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFoodRepository
    {
        Task<IEnumerable<Food>> GetAllFoodsAsync(bool trackChanges);
        Task<IEnumerable<Food>> GetFoodsByCategoryAsync(Guid categoryId, bool trackChanges);    
        Task<Food> GetFoodAsync(Guid foodId,  bool trackChanges);
        void CreateFood(Food food);
        void DeleteFood(Food food);    
        
    }
}
