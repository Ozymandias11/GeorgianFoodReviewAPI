using Shared.DataTransferObjects.DtosForGet;
using Shared.DataTransferObjects.DtosForPost;
using Shared.DataTransferObjects.DtosForPut;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllCountriesAsync(CountryParameters countryParameters ,bool trackChanges);
        Task<CountryDto> GetCountryAsync(Guid countryId, bool trackChanges);
        Task<CountryDto> CreateCountryAsync(CountryForCreationDto country);
        Task DeleteCountryAsync(Guid countryId, bool trackChanges);
        Task UpdateCountryAsync(Guid countryId,CountryForUpdateDto country,  bool trackChanges);

    }
}
