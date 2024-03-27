using Contracts;
using Entities.Models;
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
       

        public IEnumerable<Country> GetAllCountries(bool trackChanges)
            => FindAll(trackChanges).OrderBy(c => c.Name).ToList();

        public Country GetCountry(Guid countryId, bool trackChanges)
            => FindByCondition(c => c.Id == countryId, trackChanges)
            .FirstOrDefault();

        public Country GetCountryByName(string name)
            => FindByCondition(c => c.Name.Trim().ToUpper() == name.TrimEnd().ToUpper(), trackChanges:false)
            .FirstOrDefault();
    }
}
