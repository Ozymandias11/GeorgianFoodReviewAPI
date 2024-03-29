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
        private readonly ValidationService _validationService;

        public CategoryService(IRepositoryManager repository, ILoggerManager logger, 
            IMapper mapper, ValidationService validationService)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _validationService = validationService;

        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryToCreateDto category)
        {
            var categoryDuplicate = await _repository.Category.GetCategoryByNameAsync(category.name);

            if(categoryDuplicate != null)
                throw new CategoryAlreadyExistsException(category.name);


            var categoryEntity = _mapper.Map<Category>(category);

            _repository.Category.CreateCategory(categoryEntity);
            await _repository.SaveAsync();

            var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);

            return categoryToReturn;

        }

        public async Task DeleteCategoryAsync(Guid categoryId, bool trackChanges)
        {
            var category = await _validationService.GetCategoryAndCheckIfItExists(categoryId, trackChanges);
            
            var foods = await _repository.Food.GetFoodsByCategoryAsync(categoryId, trackChanges);

           foreach(var food in foods)
            {
                _repository.Food.DeleteFood(food);
            }

            _repository.Category.DeleteCategory(category);
             await _repository.SaveAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges)
        {
            
                var categories = await _repository.Category.GetAllCategoriesAsync(trackChanges);

                var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);

                return categoriesDto;
            
        }

        public async Task<CategoryDto> GetCategoryAsync(Guid categoryId, bool trackChanges)
        {

            var category = await _validationService.GetCategoryAndCheckIfItExists(categoryId, trackChanges);

            var categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }

        public async Task UpdateCatgeoryAsync(Guid categoryId, CategoryForUpdateDto category, bool trackChanges)
        {
            var categoryEntity = await _validationService.GetCategoryAndCheckIfItExists(categoryId, trackChanges);


            _mapper.Map(category, categoryEntity);
            await _repository.SaveAsync();


        }



    }
}
