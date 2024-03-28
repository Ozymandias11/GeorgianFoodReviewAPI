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
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public void CreateCategory(Category category) => Create(category);

        public void DeleteCategory(Category category) => Delete(category);
        
            
        

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
            => await FindAll(trackChanges).OrderBy(c => c.Name).ToListAsync();

        public async Task<Category> GetCategoryAsync(Guid categoryId, bool trackChanges)
            => await FindByCondition(c => c.CategoryId == categoryId, trackChanges).
            FirstOrDefaultAsync();

        public async Task<Category> GetCategoryByNameAsync(string name)
            =>await  FindByCondition(c => c.Name.Trim().ToUpper() == name.TrimEnd().ToUpper(), trackChanges:false)
            .FirstOrDefaultAsync();
    }
}
