using Contracts;
using Entities.Models;
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
        
            
        

        public IEnumerable<Reviewer> GetAllReveiwers(bool trackChanges)
             => FindAll(trackChanges).OrderBy(re => re.Id).ToList();

        public IEnumerable<Reviewer> GetReviewersOfCountry(Guid countryId, bool trackChanges)
            => FindByCondition(re => re.CountryId == countryId, trackChanges).ToList();

        public Reviewer GetReviewever(Guid reviewerId, bool trackChanges)
            => FindByCondition(re => re.Id == reviewerId, trackChanges).FirstOrDefault();
    }
}
