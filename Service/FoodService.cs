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
    public class FoodService : IFoodService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public FoodService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

        }

        public async Task<FoodDto> CreateFoodAsync(Guid categoryId, FoodForCreationDto food, bool trackChanges)
        {
            var categoryEntity = await _repository.Category.GetCategoryAsync(categoryId, trackChanges);

            if(categoryEntity is null)
                throw new CategoryNotFoundException(categoryId);
            

            var foodEntity = _mapper.Map<Food>(food);

            _repository.Food.CreateFood(foodEntity);
            _repository.FoodCategory.CreateFoodCategory(foodEntity, categoryEntity);
            await _repository.SaveAsync();

            var FoodToReturn = _mapper.Map<FoodDto>(foodEntity);

            return FoodToReturn;

        }

        public async Task DeleteFoodAsync(Guid foodId, bool trackChanges)
        {
            var foodEntity = await _repository.Food.GetFoodAsync(foodId, trackChanges);
            
            if(foodEntity is null)
                throw new FoodNotFoundException(foodId);

            _repository.Food.DeleteFood(foodEntity);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<FoodDto>> GetAllFoodsAsync(bool trackChanges)
        {
            var foods = await _repository.Food.GetAllFoodsAsync(trackChanges);
            var foodsDto = _mapper.Map<IEnumerable<FoodDto>>(foods);

            return foodsDto;
        }

        public async Task<FoodDto> GetFoodAsync(Guid foodId, bool trackChanges)
        {
            var food = await _repository.Food.GetFoodAsync(foodId, trackChanges);

            if(food is null)
                throw new FoodNotFoundException(foodId);
            

            var foodDto = _mapper.Map<FoodDto>(food);
            return foodDto;

        }

        public async Task UpdateFoodAsync(Guid foodId, FoodForUpdateDto food, bool trackChanges)
        {
            var foodEntity = await _repository.Food.GetFoodAsync(foodId, trackChanges);

            if (foodEntity is null)
                throw new FoodNotFoundException(foodId);

            _mapper.Map(food, foodEntity);  
            await _repository.SaveAsync();

        }
    }
}
