using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures
{
    public class ReviewParameters : RequestParameters
    {

        public ReviewParameters() => OrderBy = "Title";
        
            
        
        public uint MinRating { get; set; }
        public uint MaxRating { get; set; } = 10;

        public bool ValidRatingRange => MaxRating > MinRating;

    }
}
