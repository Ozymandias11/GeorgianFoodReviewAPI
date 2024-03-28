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

        public async Task<CountryDto> CreateCountryAsync(CountryForCreationDto country)
        {

            var duplicateCountry = await _repository.Country.GetCountryByNameAsync(country.Name);

            if(duplicateCountry != null)
            {
                throw new CountryAlreadyExistsException(country.Name);
            }

            var countryEntity = _mapper.Map<Country>(country);

            _repository.Country.CreateCountry(countryEntity);
            await _repository.SaveAsync();

            var countryToReturn = _mapper.Map<CountryDto>(countryEntity);
            return countryToReturn;
        }

        public async Task<IEnumerable<CountryDto>> GetAllCountriesAsync(bool trackChanges)
        {
            var countries = await _repository.Country.GetAllCountriesAsync(trackChanges);

            var countriesDto = _mapper.Map<IEnumerable<CountryDto>>(countries);
            return countriesDto;

        }

        public async Task<CountryDto> GetCountryAsync(Guid countryId, bool trackChanges)
        {
            var country = await _repository.Country.GetCountryAsync(countryId, trackChanges);

            if(country is null)
            {
                throw new CountryNotFoundException(countryId);
            }

            var countryDto = _mapper.Map<CountryDto>(country);
            return countryDto;


        }

        public async Task DeleteCountryAsync(Guid countryId, bool trackChanges)
        {
            var country = await _repository.Country.GetCountryAsync(countryId, trackChanges);

            if (country is null)
                throw new CountryNotFoundException(countryId);

            _repository.Country.DeleteCountry(country);
            await _repository.SaveAsync();
        }

        public async Task UpdateCountryAsync(Guid countryId,CountryForUpdateDto country, bool trackChanges)
        {
            var countryEntity = await _repository.Country.GetCountryAsync(countryId, trackChanges);

            if(countryEntity is null)
                throw new CountryNotFoundException(countryId);

            _mapper.Map(country, countryEntity);
            await _repository.SaveAsync();

        }
    }
}
