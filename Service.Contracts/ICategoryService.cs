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
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges);
        Task<CategoryDto> GetCategoryAsync(Guid categoryId, bool trackChanges);
        Task<CategoryDto> CreateCategoryAsync(CategoryToCreateDto category);
        Task DeleteCategoryAsync(Guid categoryId, bool trackChanges);
        Task UpdateCatgeoryAsync(Guid categoryId, CategoryForUpdateDto category, bool trackChanges);
    }
}
