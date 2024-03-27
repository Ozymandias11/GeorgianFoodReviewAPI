using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries(bool trackChanges);
        Country GetCountry(Guid countryId, bool trackChanges);
        Country GetCountryByName(string name);
        void CreateCountry(Country country);
        void DeleteCountry(Country country);

    }
}
