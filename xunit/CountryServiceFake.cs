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

namespace xunit
{
    public class CountryServiceFake : ICountryService
    {

        private readonly List<Country>? _countries;

        public CountryServiceFake()
        {
            var _countries = new List<Country>
                {
                    new Country
                    {
                        Id = Guid.NewGuid(),
                        Name = "United States",
                        Reviewevers = new List<Reviewer>
                        {
                            new Reviewer { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe" },
                            new Reviewer { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith" }
                        }
                    },
                    new Country
                    {
                        Id = Guid.NewGuid(),
                        Name = "United Kingdom",
                        Reviewevers = new List<Reviewer>
                        {
                            new Reviewer { Id = Guid.NewGuid(), FirstName = "Alice", LastName = "Johnson" },
                            new Reviewer { Id = Guid.NewGuid(), FirstName = "Bob", LastName = "Williams" }
                        }
                    },
                    new Country
                    {
                        Id = Guid.NewGuid(),
                        Name = "Canada",
                        Reviewevers = new List<Reviewer>
                        {
                            new Reviewer { Id = Guid.NewGuid(), FirstName = "Michael", LastName = "Brown" },
                            new Reviewer { Id = Guid.NewGuid(), FirstName = "Sarah", LastName = "Davis" }
                        }
                    }
};


        }

        public Task<CountryDto> CreateCountryAsync(CountryForCreationDto country)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCountryAsync(Guid countryId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CountryDto>> GetAllCountriesAsync(CountryParameters countryParameters, bool trackChanges)
        {

            var countries = _countries.Select(c => new CountryDto(c.Id, c.Name));

            return Task.FromResult(countries.AsEnumerable());


        }

        public Task<CountryDto> GetCountryAsync(Guid countryId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCountryAsync(Guid countryId, CountryForUpdateDto country, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
