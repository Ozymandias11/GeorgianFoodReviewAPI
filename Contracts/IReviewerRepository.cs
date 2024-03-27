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
        IEnumerable<Reviewer> GetAllReveiwers(bool trackChanges);
        Reviewer GetReviewever(Guid reviewerId, bool trackChanges);
        IEnumerable<Reviewer> GetReviewersOfCountry(Guid countryId, bool trackChanges);
        void CreateReviewerForCountry(Guid countryId, Reviewer reviewever);
        void DeleteReviewer(Reviewer reviewer);
    }
}
