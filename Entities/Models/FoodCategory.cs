using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class FoodCategory
    {
        public Guid FoodId { get; set; }
        public Guid CategoryId { get; set; }
        public Food Food { get; set; }
        public Category Category { get; set; }
    }
}
