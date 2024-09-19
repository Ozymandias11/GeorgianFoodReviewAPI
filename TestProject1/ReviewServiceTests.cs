using AutoMapper;
using Contracts;
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
   public class ReviewServiceTests
    {
        private readonly Mock<IRepositoryManager> _mockRepository;
        private readonly Mock<ILoggerManager> _mockLogger;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ValidationService> _mockValidationService;
        private readonly ReviewService _reviewService;



        public ReviewServiceTests()
        {
            _mockRepository = new Mock<IRepositoryManager>();
            _mockLogger = new Mock<ILoggerManager>();
            _mockMapper = new Mock<IMapper>();
            _mockValidationService = new Mock<ValidationService>(_mockRepository.Object);



            var mockReviewReposiotry = new Mock<IReviewRepository>();
            _mockRepository.Setup(r => r.Review);

            _reviewService = new ReviewService(
                _mockRepository.Object,
                _mockLogger.Object,
                _mockMapper.Object,
                _mockValidationService.Object);
        }

    

    }
}
