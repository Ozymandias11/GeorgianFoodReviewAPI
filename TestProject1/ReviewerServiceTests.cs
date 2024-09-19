using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Moq;
using Service;
using Service.Contracts;
using Shared.DataTransferObjects.DtosForGet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class ReviewerServiceTests
    {
        private readonly Mock<IRepositoryManager> _mockRepository;
        private readonly Mock<ILoggerManager> _mockLogger;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ValidationService> _mockValidationService;
        private readonly ReviewerService _reviewerService;

        public ReviewerServiceTests()
        {
            _mockRepository = new Mock<IRepositoryManager>();
            _mockLogger = new Mock<ILoggerManager>();
            _mockMapper = new Mock<IMapper>();
            _mockValidationService = new Mock<ValidationService>(_mockRepository.Object);

            var mockReviewerRepository = new Mock<IReviewerRepository>();   
            _mockRepository.Setup(r => r.Reviewer).Returns(mockReviewerRepository.Object);

            _reviewerService = new ReviewerService(
                _mockRepository.Object,
                _mockLogger.Object,
                _mockMapper.Object,
                _mockValidationService.Object
                );



        }



        [Fact]
        public async Task GetReviewerAsync_Returns_CorrectReviewerDto_WhenRevierExists()
        {
            var ReviewerID = Guid.NewGuid();
            var FirstName = "Test FirstName";
            var LastName = "Test LastName";


            var Reviewer = new Reviewer { FirstName = FirstName, LastName = LastName };
            var expectedReviewerDto = new ReviewerDto(ReviewerID, FirstName, LastName);

            _mockRepository.Setup(r => r.Reviewer.GetRevieweverAsync(ReviewerID, false))
                .ReturnsAsync(Reviewer);

            _mockValidationService.Setup(v => v.GetReviewerAndCheckIfItExists(ReviewerID, false))
                .ReturnsAsync(Reviewer);

            _mockMapper.Setup(m => m.Map<ReviewerDto>(Reviewer)).Returns(expectedReviewerDto);

            var result = await _reviewerService.GetReviewerAsync(ReviewerID, false);

            Assert.Equal(expectedReviewerDto, result);  


        }

        [Fact]
        public async Task GetReviewerAsync_ThrowsReviewerNotFoundException_WhenReviewer_NotExists()
        {

            var ReviewerID = Guid.NewGuid();


            _mockValidationService.Setup(v => v.GetReviewerAndCheckIfItExists(ReviewerID, false))
                .ThrowsAsync(new ReviewerNotFoundException(ReviewerID));

            await Assert.ThrowsAsync<ReviewerNotFoundException>(() => _reviewerService.GetReviewerAsync(ReviewerID, false));

        }

    
    }
}
