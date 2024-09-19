using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Moq;
using Service;
using Shared.DataTransferObjects.DtosForGet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class CategoryServiceTests
    {
        private readonly Mock<IRepositoryManager> _mockRepository;
        private readonly Mock<ILoggerManager> _mockLogger;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ValidationService> _mockValidationService;
        private readonly CategoryService _categoryService;

        public CategoryServiceTests()
        {
            _mockRepository = new Mock<IRepositoryManager>();
            _mockLogger = new Mock<ILoggerManager>();
            _mockMapper = new Mock<IMapper>();
            _mockValidationService = new Mock<ValidationService>(_mockRepository.Object);

            var mockCategoryRepository = new Mock<ICategoryRepository>();
            _mockRepository.Setup(r => r.Category).Returns(mockCategoryRepository.Object);

            _categoryService = new CategoryService(
                _mockRepository.Object,
                _mockLogger.Object,
                _mockMapper.Object,
                _mockValidationService.Object
                );
        }


        [Fact]
        public async Task GetCategoryAsync_ReturnsCorrectDto_When_Category_Exists()
        {
            var categoryID = Guid.NewGuid();
            var catgeoryName = "Test Category";

            var category = new Category { CategoryId = categoryID, Name = catgeoryName };
            var expectedCategoryDto = new CategoryDto(categoryID, catgeoryName);


            _mockRepository.Setup(r => r.Category.GetCategoryAsync(categoryID, false));
            _mockMapper.Setup(m => m.Map<CategoryDto>(category)).Returns(expectedCategoryDto);

            _mockValidationService.Setup(v => v.GetCategoryAndCheckIfItExists(categoryID, false)).ReturnsAsync(category);

            var result = await _categoryService.GetCategoryAsync(categoryID, false);

            Assert.Equal(expectedCategoryDto, result);



        }

        [Fact]
        public async Task GetCategoryAsync_ThrowsCategoryNotFoundException_When_Category_Not_Found()
        {
            var categoryID = Guid.NewGuid();
            _mockValidationService.Setup(v => v.GetCategoryAndCheckIfItExists(categoryID, false))
                .ThrowsAsync(new CategoryNotFoundException(categoryID));

            await Assert.ThrowsAsync<CategoryNotFoundException>(() => _categoryService.GetCategoryAsync(categoryID, false));
        }

        //[Fact]
        //public async Task DeleteCategoryAsync_ShouldDeleteCategoryAndAssociateFoods_WhenExists()
        //{
        //    var CategoryId = Guid.NewGuid();
        //    var CategoryName = "Test Category";

        //    var Category = new Category { CategoryId = CategoryId, Name = CategoryName };

        //    var food1 = new Food { Id = Guid.NewGuid(), Name = "Food 1" };
        //    var food2 = new Food { Id = Guid.NewGuid(), Name = "Food 2" };

        //    var foods = new List<Food> { food1, food2 };

        //  _mockValidationService.Setup(v => v.GetCategoryAndCheckIfItExists(CategoryId, false))
        //        .ReturnsAsync(Category);

        //    var mockFoodRepository = new Mock<IFoodRepository>();
        //    mockFoodRepository.Setup(r => r.get)



        //}




    }
}
