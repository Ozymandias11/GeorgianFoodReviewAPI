using Shared.DataTransferObjects.DtosForGet;
using Shared.DataTransferObjects.DtosForPost;
using Shared.DataTransferObjects.DtosForPut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICountryService
    {
        IEnumerable<CountryDto> GetAllCountries(bool trackChanges);
        CountryDto GetCountry(Guid countryId, bool trackChanges);
        CountryDto CreateCountry(CountryForCreationDto country);
        void DeleteCountry(Guid countryId, bool trackChanges);
        void UpdateCountry(Guid countryId,CountryForUpdateDto country,  bool trackChanges);

    }
}
