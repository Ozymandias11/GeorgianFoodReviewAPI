using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
   public interface IReviewerRepository
    {
        Task<IEnumerable<Reviewer>> GetAllReveiwersAsync(bool trackChanges);
        Task<Reviewer> GetRevieweverAsync(Guid reviewerId, bool trackChanges);
        Task<IEnumerable<Reviewer>> GetReviewersOfCountryAsync(Guid countryId, bool trackChanges);
        void CreateReviewerForCountry(Guid countryId, Reviewer reviewever);
        void DeleteReviewer(Reviewer reviewer);
    }
}
