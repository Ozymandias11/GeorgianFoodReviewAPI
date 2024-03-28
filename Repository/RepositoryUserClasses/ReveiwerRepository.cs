using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryUserClasses
{
    public class ReveiwerRepository : RepositoryBase<Reviewer>, IReviewerRepository
    {
        public ReveiwerRepository(RepositoryContext repositoryContext) : base(repositoryContext) 
        {
            
        }

        public void CreateReviewerForCountry(Guid countryId, Reviewer reviewever)
        {
           reviewever.CountryId = countryId;
           Create(reviewever);
        }

        public void DeleteReviewer(Reviewer reviewer) => Delete(reviewer);
        
            
        

        public async Task<IEnumerable<Reviewer>> GetAllReveiwersAsync(bool trackChanges)
             => await FindAll(trackChanges).OrderBy(re => re.Id).ToListAsync();

        public async Task<IEnumerable<Reviewer>> GetReviewersOfCountryAsync(Guid countryId, bool trackChanges)
            => await FindByCondition(re => re.CountryId == countryId, trackChanges).ToListAsync();

        public async Task<Reviewer> GetRevieweverAsync(Guid reviewerId, bool trackChanges)
            => await FindByCondition(re => re.Id == reviewerId, trackChanges).FirstOrDefaultAsync();
    }
}
