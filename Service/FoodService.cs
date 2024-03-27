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

        public FoodDto CreateFood(Guid categoryId, FoodForCreationDto food, bool trackChanges)
        {
            var categoryEntity = _repository.Category.GetCategory(categoryId, trackChanges);

            if(categoryEntity is null)
            {
                throw new CategoryNotFoundException(categoryId);
            }

            var foodEntity = _mapper.Map<Food>(food);

            _repository.Food.CreateFood(foodEntity);
            _repository.FoodCategory.CreateFoodCategory(foodEntity, categoryEntity);
            _repository.Save();

            var FoodToReturn = _mapper.Map<FoodDto>(foodEntity);

            return FoodToReturn;

        }

        public void DeleteFood(Guid foodId, bool trackChanges)
        {
            var foodEntity = _repository.Food.GetFood(foodId, trackChanges);
            
            if(foodEntity is null)
                throw new FoodNotFoundException(foodId);

            _repository.Food.DeleteFood(foodEntity);
            _repository.Save();
        }

        public IEnumerable<FoodDto> GetAllFoods(bool trackChanges)
        {
            var foods = _repository.Food.GetAllFoods(trackChanges);
            var foodsDto = _mapper.Map<IEnumerable<FoodDto>>(foods);

            return foodsDto;
        }

        public FoodDto GetFood(Guid foodId, bool trackChanges)
        {
            var food = _repository.Food.GetFood(foodId, trackChanges);

            if(food is null)
            {
                throw new FoodNotFoundException(foodId);
            }

            var foodDto = _mapper.Map<FoodDto>(food);
            return foodDto;

        }

        public void UpdateFood(Guid foodId, FoodForUpdateDto food, bool trackChanges)
        {
            var foodEntity = _repository.Food.GetFood(foodId, trackChanges);

            if (foodEntity is null)
                throw new FoodNotFoundException(foodId);

            _mapper.Map(food, foodEntity);  
            _repository.Save();

        }
    }
}
