using Shared.DataTransferObjects.DtosForGet;
using Shared.DataTransferObjects.DtosForPost;
using Shared.DataTransferObjects.DtosForPut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IFoodService
    {
        IEnumerable<FoodDto> GetAllFoods(bool trackChanges);
        FoodDto GetFood(Guid foodId, bool trackChanges);
        FoodDto CreateFood(Guid CategoryID, FoodForCreationDto food, bool trackChanges);
        void DeleteFood(Guid foodId, bool trackChanges);
        void UpdateFood(Guid foodId, FoodForUpdateDto food, bool trackChanges); 
    }
}
