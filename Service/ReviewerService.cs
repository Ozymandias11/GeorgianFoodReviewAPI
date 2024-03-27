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
    public class ReviewerService : IReviewerService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ReviewerService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

        }

        public ReviewerDto CreateReviewerForCountry(Guid countryId, ReviewerForCreationDto reviewer, bool trackChanges)
        {
            var country = _repository.Country.GetCountry(countryId, trackChanges);

            if(country is null)
                throw new CountryNotFoundException(countryId);

            var ReviewerEntity = _mapper.Map<Reviewer>(reviewer);

            _repository.Reviewer.CreateReviewerForCountry(countryId, ReviewerEntity);
            _repository.Save();

            var reviewerToReturn = _mapper.Map<ReviewerDto>(ReviewerEntity);

            return reviewerToReturn;

        }

        public void DeleteReviewer(Guid reviewerId, bool trackChanges)
        {
            var reviewer = _repository.Reviewer.GetReviewever(reviewerId, trackChanges);

            if(reviewer is null)
                throw new ReviewerNotFoundException(reviewerId);

            _repository.Reviewer.DeleteReviewer(reviewer);
            _repository.Save();


        }

        public IEnumerable<ReviewerDto> GetAllReviewers(bool trackChanges)
        {
            var reviewers = _repository.Reviewer.GetAllReveiwers(trackChanges);

            var reviewersDto = _mapper.Map<IEnumerable<ReviewerDto>>(reviewers);

            return reviewersDto;

        }

        public ReviewerDto GetReviewer(Guid id, bool trackChanges)
        {
            var reviewer = _repository.Reviewer.GetReviewever(id, trackChanges);

            if(reviewer is null)
            {
                throw new ReviewerNotFoundException(id);
            }

            var reviewerDto = _mapper.Map<ReviewerDto>(reviewer);
            return reviewerDto;


        }

        public (ReviewerForUpdateDto reviewerToPatch, Reviewer reviwerEntity) 
            GetReviewerForPatch(Guid countryId, Guid reviewerId, bool countryTrackChanges, bool reviewerTrackChanges)
        {
            var country = _repository.Country.GetCountry(countryId, countryTrackChanges);
            if (country is null)
                throw new CountryNotFoundException(countryId);

            var reviewerEntity = _repository.Reviewer.GetReviewever(reviewerId, reviewerTrackChanges);
            if(reviewerEntity is null)
                throw new ReviewerNotFoundException(reviewerId);

            var reviewToPatch = _mapper.Map<ReviewerForUpdateDto>(reviewerEntity);

            return (reviewToPatch, reviewerEntity);


            

        }

        public IEnumerable<ReviewerDto> GetReviewersOfCountry(Guid countryId, bool trackChanges)
        {
            var country = _repository.Country.GetCountry(countryId, trackChanges);

            if(country is null)
                throw new CountryNotFoundException(countryId);
  

            var reviewers = _repository.Reviewer.GetReviewersOfCountry(countryId, trackChanges);

            var reviewersDto = _mapper.Map<IEnumerable<ReviewerDto>>(reviewers);
            return reviewersDto;
        }

        public void SaveChangesForPatch(ReviewerForUpdateDto reviewerToPatch, Reviewer reviewEntity)
        {
            _mapper.Map(reviewerToPatch, reviewEntity);
            _repository.Save();
        }

        public void UpdateReviewerForCountry(Guid countryId, Guid ReviewerId, ReviewerForUpdateDto reviewer,
                                     bool countryTrackChanges, bool reviewerTrackChanges)
        {
            var country = _repository.Country.GetCountry(countryId, countryTrackChanges);

            if(country is null)
                throw new CountryNotFoundException(countryId);

            var reviewerEntity = _repository.Reviewer.GetReviewever(ReviewerId, reviewerTrackChanges);

            if (reviewerEntity is null)
                throw new ReviewerNotFoundException(ReviewerId);

            _mapper.Map(reviewer, reviewerEntity);
            _repository.Save();


        }
    }
}
