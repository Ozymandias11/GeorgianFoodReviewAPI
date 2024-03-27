using Contracts;
using Entities.Models;
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
        
            
        

        public IEnumerable<Category> GetAllCategories(bool trackChanges)
            => FindAll(trackChanges).OrderBy(c => c.Name).ToList();

        public Category GetCategory(Guid categoryId, bool trackChanges)
            => FindByCondition(c => c.CategoryId == categoryId, trackChanges).
            FirstOrDefault();

        public Category GetCategoryByName(string name)
            => FindByCondition(c => c.Name.Trim().ToUpper() == name.TrimEnd().ToUpper(), trackChanges:false)
            .FirstOrDefault();
    }
}
