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
        IEnumerable<CategoryDto> GetAllCategories(bool trackChanges);
        CategoryDto GetCategory(Guid categoryId, bool trackChanges);
        CategoryDto CreateCategory(CategoryToCreateDto category);
        void DeleteCategory(Guid categoryId, bool trackChanges);
        void UpdateCatgeory(Guid categoryId, CategoryForUpdateDto category, bool trackChanges);
    }
}
