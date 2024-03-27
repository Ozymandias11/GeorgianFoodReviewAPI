using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class ReviewNotFoundException : NotFoundException
    {
        public ReviewNotFoundException(Guid reviewId)
            :base($"The review with id: {reviewId} does not exists in the database")
        {
            
        }
    }
}
