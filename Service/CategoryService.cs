using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.DtosForGet;
using Shared.DataTransferObjects.DtosForPost;
using Shared.DataTransferObjects.DtosForPut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CategoryService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            
        }

        public CategoryDto CreateCategory(CategoryToCreateDto category)
        {
            var categoryDuplicate = _repository.Category.GetCategoryByName(category.name);
            if(categoryDuplicate != null)
            {
                throw new CategoryAlreadyExistsException(category.name);
            }

            var categoryEntity = _mapper.Map<Category>(category);

            _repository.Category.CreateCategory(categoryEntity);
            _repository.Save();

            var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);

            return categoryToReturn;

        }

        public void DeleteCategory(Guid categoryId, bool trackChanges)
        {
            var category = _repository.Category.GetCategory(categoryId, trackChanges);
            
            if(category is null)
                throw new CategoryNotFoundException(categoryId);

            var foods = _repository.Food.GetFoodsByCategory(categoryId, trackChanges);

           foreach(var food in foods)
            {
                _repository.Food.DeleteFood(food);
            }

            _repository.Category.DeleteCategory(category);
            _repository.Save();
        }

        public IEnumerable<CategoryDto> GetAllCategories(bool trackChanges)
        {
            
                var categories = _repository.Category.GetAllCategories(trackChanges);

                var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);

                return categoriesDto;
            
        }

        public CategoryDto GetCategory(Guid categoryId, bool trackChanges)
        {
            var category = _repository.Category.GetCategory(categoryId, trackChanges);

            if(category is null)
                throw new CategoryNotFoundException(categoryId);

            var categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }

        public void UpdateCatgeory(Guid categoryId, CategoryForUpdateDto category, bool trackChanges)
        {
            var categoryEntity = _repository.Category.GetCategory(categoryId, trackChanges);

            if (categoryEntity is null)
                throw new CategoryNotFoundException(categoryId);

            _mapper.Map(category, categoryEntity);
            _repository.Save();


        }
    }
}
