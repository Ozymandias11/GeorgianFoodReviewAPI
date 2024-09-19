using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Moq;
using Service;
using Shared.DataTransferObjects.DtosForGet;
using Shared.DataTransferObjects.DtosForPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
        public class FoodServiceTests
        {
            private readonly Mock<IRepositoryManager> _mockRepository;
            private readonly Mock<ILoggerManager> _mockLogger;
            private readonly Mock<IMapper> _mockMapper;
            private readonly Mock<ValidationService> _mockValidationService;
            private readonly FoodService _foodService;

            

            public FoodServiceTests()
            {
                _mockRepository = new Mock<IRepositoryManager>();
                _mockLogger = new Mock<ILoggerManager>();
                _mockMapper = new Mock<IMapper>();
                _mockValidationService = new Mock<ValidationService>(_mockRepository.Object);


                var mockFoodRepository = new Mock<IFoodRepository>();
                _mockRepository.Setup(r => r.Food).Returns(mockFoodRepository.Object);

                _foodService = new FoodService(
                    _mockRepository.Object,
                    _mockLogger.Object,
                    _mockMapper.Object,
                    _mockValidationService.Object);
            }

            [Fact]
            public async Task GetFoodAsync_ReturnsCorrectFoodDto_WhenFoodExists()
            {

                var foodId = Guid.NewGuid();
                var foodName = "Test Food";
                var foodDescription = "This is a test food.";
                var food = new Food { Id = foodId, Name = foodName, Description = foodDescription };
                var expectedFoodDto = new FoodDto(foodId, foodName, foodDescription);

                _mockRepository.Setup(r => r.Food.GetFoodAsync(foodId,false))
                    .ReturnsAsync(food);

                _mockMapper.Setup(m => m.Map<FoodDto>(food))
                    .Returns(expectedFoodDto);

                _mockValidationService.Setup(v => v.GetFoodAndCheckIfItExists(foodId, false))
                    .ReturnsAsync(food);


                var result = await _foodService.GetFoodAsync(foodId, false);


                Assert.Equal(expectedFoodDto, result);
            }

            [Fact]
            public async Task GetFoodAsync_ThrowsFoodNotFoundException_WhenFoodNotFound()
            {
                var foodID = Guid.NewGuid();

                _mockValidationService.Setup(v => v.GetFoodAndCheckIfItExists(foodID, false))
                    .ThrowsAsync(new FoodNotFoundException(foodID));

                await Assert.ThrowsAsync<FoodNotFoundException>(() =>
                _foodService.GetFoodAsync(foodID, false));

            }

            [Fact]
            public async Task DeleteFoodAsync_DeletesFoodFromRepository_When_Food_Exists()
            {
                var foodId = Guid.NewGuid();
                var foodEntity = new Food { Id = foodId, Name = "Test Food", Description = "Test Description" };

                _mockValidationService.Setup(v => v.GetFoodAndCheckIfItExists(foodId, false))
                    .ReturnsAsync(foodEntity);

                await _foodService.DeleteFoodAsync(foodId, false);

                _mockRepository.Verify(r => r.Food.DeleteFood(foodEntity), Times.Once());
                _mockRepository.Verify(r => r.SaveAsync(), Times.Once());




            }

            


        }
    

}

    