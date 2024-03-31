using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class MaxRatingRangeBadRequestException : BadRequestException 
    {
        public MaxRatingRangeBadRequestException() : base("Max age can't be less than min age")
        {
            
        }
    }
}
