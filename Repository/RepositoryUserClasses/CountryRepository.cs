using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryUserClasses
{
    public  class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public void CreateCountry(Country country) => Create(country);

        public void DeleteCountry(Country country) => Delete(country);  
       

        public async Task<IEnumerable<Country>> GetAllCountriesAsync(CountryParameters countryParameters ,bool trackChanges)
            => await FindAll(trackChanges).OrderBy(c => c.Name)
            .Skip((countryParameters.PageNumber - 1) * countryParameters.PageSize)
            .Take(countryParameters.PageSize)
            .ToListAsync();

        public async Task<Country> GetCountryAsync(Guid countryId, bool trackChanges)
            =>await FindByCondition(c => c.Id == countryId, trackChanges)
            .FirstOrDefaultAsync();

        public async Task<Country> GetCountryByNameAsync(string name)
            => await FindByCondition(c => c.Name.Trim().ToUpper() == name.TrimEnd().ToUpper(), trackChanges:false)
            .FirstOrDefaultAsync();
    }
}
