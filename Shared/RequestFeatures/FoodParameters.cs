using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures
{
   public class FoodParameters : RequestParameters
    {
        public FoodParameters() => OrderBy = "name";
        public string? SearchTerm { get; set; }
    }
}
