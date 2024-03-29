using Shared.DataTransferObjects.DtosForGet;
using Shared.DataTransferObjects.DtosForPost;
using Shared.DataTransferObjects.DtosForPut;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IFoodService
    {
        Task<IEnumerable<FoodDto>> GetAllFoodsAsync(FoodParameters food, bool trackChanges);
        Task<FoodDto> GetFoodAsync(Guid foodId, bool trackChanges);
        Task<FoodDto> CreateFoodAsync(Guid CategoryID, FoodForCreationDto food, bool trackChanges);
        Task DeleteFoodAsync(Guid foodId, bool trackChanges);
        Task UpdateFoodAsync(Guid foodId, FoodForUpdateDto food, bool trackChanges); 
    }
}
