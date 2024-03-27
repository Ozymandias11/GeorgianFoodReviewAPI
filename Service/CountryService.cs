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
    public class CountryService : ICountryService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CountryService (IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

        }

        public CountryDto CreateCountry(CountryForCreationDto country)
        {

            var duplicateCountry = _repository.Country.GetCountryByName(country.Name);

            if(duplicateCountry != null)
            {
                throw new CountryAlreadyExistsException(country.Name);
            }

            var countryEntity = _mapper.Map<Country>(country);

            _repository.Country.CreateCountry(countryEntity);
            _repository.Save();

            var countryToReturn = _mapper.Map<CountryDto>(countryEntity);
            return countryToReturn;
        }

        public IEnumerable<CountryDto> GetAllCountries(bool trackChanges)
        {
            var countries = _repository.Country.GetAllCountries(trackChanges);

            var countriesDto = _mapper.Map<IEnumerable<CountryDto>>(countries);
            return countriesDto;

        }

        public CountryDto GetCountry(Guid countryId, bool trackChanges)
        {
            var country = _repository.Country.GetCountry(countryId, trackChanges);

            if(country is null)
            {
                throw new CountryNotFoundException(countryId);
            }

            var countryDto = _mapper.Map<CountryDto>(country);
            return countryDto;


        }

        public void DeleteCountry(Guid countryId, bool trackChanges)
        {
            var country = _repository.Country.GetCountry(countryId, trackChanges);

            if (country is null)
                throw new CountryNotFoundException(countryId);

            _repository.Country.DeleteCountry(country);
            _repository.Save();
        }

        public void UpdateCountry(Guid countryId,CountryForUpdateDto country, bool trackChanges)
        {
            var countryEntity = _repository.Country.GetCountry(countryId, trackChanges);

            if(countryEntity is null)
                throw new CountryNotFoundException(countryId);

            _mapper.Map(country, countryEntity);
            _repository.Save();

        }
    }
}
