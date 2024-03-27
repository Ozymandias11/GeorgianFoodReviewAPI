using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class FoodNotFoundException : NotFoundException
    {
        public FoodNotFoundException(Guid foodId) : base($"Food with id {foodId}" +
            $" does not exists in the database")
        {
            
        }
    }
}
