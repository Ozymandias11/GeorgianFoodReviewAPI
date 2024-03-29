using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.DtosForGet;
using Shared.DataTransferObjects.DtosForPost;
using Shared.DataTransferObjects.DtosForPut;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ReviewerService : IReviewerService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly ValidationService _validationService;

        public ReviewerService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, 
                                ValidationService validation)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _validationService = validation;

        }

        public async Task<ReviewerDto> CreateReviewerForCountryAsync(Guid countryId, ReviewerForCreationDto reviewer, bool trackChanges)
        {
            var country = await _validationService.GetCountryAndCheckItIfExists(countryId, trackChanges);

            var ReviewerEntity = _mapper.Map<Reviewer>(reviewer);

            _repository.Reviewer.CreateReviewerForCountry(countryId, ReviewerEntity);
             await _repository.SaveAsync();

            var reviewerToReturn = _mapper.Map<ReviewerDto>(ReviewerEntity);

            return reviewerToReturn;

        }

        public async Task DeleteReviewerAsync(Guid reviewerId, bool trackChanges)
        {
            var reviewer = await _validationService.GetReviewerAndCheckIfItExists(reviewerId, trackChanges);

            _repository.Reviewer.DeleteReviewer(reviewer);
            await _repository.SaveAsync();


        }

        public async Task<IEnumerable<ReviewerDto>> GetAllReviewersAsync(ReviewerParameters reviewerParameters, bool trackChanges)
        {
            var reviewers = await _repository.Reviewer.GetAllReveiwersAsync(reviewerParameters,trackChanges);

            var reviewersDto = _mapper.Map<IEnumerable<ReviewerDto>>(reviewers);

            return reviewersDto;

        }

        public async Task<ReviewerDto> GetReviewerAsync(Guid id, bool trackChanges)
        {
            var reviewer =  await _validationService.GetReviewerAndCheckIfItExists(id, trackChanges);

            
            var reviewerDto = _mapper.Map<ReviewerDto>(reviewer);
            return reviewerDto;


        }

        public async Task<(ReviewerForUpdateDto reviewerToPatch, Reviewer reviwerEntity)>
            GetReviewerForPatchAsync(Guid countryId, Guid reviewerId, bool countryTrackChanges, bool reviewerTrackChanges)
        {
            var country = await _repository.Country.GetCountryAsync(countryId, countryTrackChanges);
            if (country is null)
                throw new CountryNotFoundException(countryId);

            var reviewerEntity = await _validationService.GetReviewerAndCheckIfItExists(countryId, reviewerTrackChanges);
          

            var reviewToPatch = _mapper.Map<ReviewerForUpdateDto>(reviewerEntity);

            return (reviewToPatch, reviewerEntity);


            

        }

        public async Task<IEnumerable<ReviewerDto>> GetReviewersOfCountryAsync(Guid countryId, bool trackChanges)
        {
            var country = await _repository.Country.GetCountryAsync(countryId, trackChanges);

            if(country is null)
                throw new CountryNotFoundException(countryId);
  

            var reviewers = await _repository.Reviewer.GetReviewersOfCountryAsync(countryId, trackChanges);

            var reviewersDto = _mapper.Map<IEnumerable<ReviewerDto>>(reviewers);
            return reviewersDto;
        }

        public async Task SaveChangesForPatchAsync(ReviewerForUpdateDto reviewerToPatch, Reviewer reviewEntity)
        {
            _mapper.Map(reviewerToPatch, reviewEntity);
            await _repository.SaveAsync();
        }

        public async Task UpdateReviewerForCountryAsync(Guid countryId, Guid ReviewerId, ReviewerForUpdateDto reviewer,
                                     bool countryTrackChanges, bool reviewerTrackChanges)
        {
            var country = await _repository.Country.GetCountryAsync(countryId, countryTrackChanges);

            if(country is null)
                throw new CountryNotFoundException(countryId);

            var reviewerEntity = await _validationService.GetReviewerAndCheckIfItExists(ReviewerId, reviewerTrackChanges);

          
            _mapper.Map(reviewer, reviewerEntity);
            await _repository.SaveAsync();


        }
    }
}
