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
        IEnumerable<Food> GetAllFoods(bool trackChanges);
        IEnumerable<Food> GetFoodsByCategory(Guid categoryId, bool trackChanges);    
        Food GetFood(Guid foodId,  bool trackChanges);
        void CreateFood(Food food);
        void DeleteFood(Food food);    
        
    }
}
