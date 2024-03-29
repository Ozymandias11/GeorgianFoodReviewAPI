using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync(CountryParameters countryParameters,bool trackChanges);
        Task<Country> GetCountryAsync(Guid countryId, bool trackChanges);
        Task<Country> GetCountryByNameAsync(string name);
        void CreateCountry(Country country);
        void DeleteCountry(Country country);

    }
}
