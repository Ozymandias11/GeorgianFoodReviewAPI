using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class ReviewerNotFoundException : NotFoundException
    {
        public ReviewerNotFoundException(Guid reviewerId) : base($"The reviewer with id {reviewerId} " +
            $" does not exists in the database")
        {
            
        }
    }
}
