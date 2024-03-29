using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
   public interface IReviewerRepository
    {
        Task<IEnumerable<Reviewer>> GetAllReveiwersAsync(ReviewerParameters reviewerParameter,bool trackChanges);
        Task<Reviewer> GetRevieweverAsync(Guid reviewerId, bool trackChanges);
        Task<IEnumerable<Reviewer>> GetReviewersOfCountryAsync(Guid countryId, bool trackChanges);
        void CreateReviewerForCountry(Guid countryId, Reviewer reviewever);
        void DeleteReviewer(Reviewer reviewer);
    }
}
