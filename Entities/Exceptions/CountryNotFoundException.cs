using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class CountryNotFoundException : NotFoundException
    {
        public CountryNotFoundException(Guid categoryId) : base($"Country with id: {categoryId}" +
            $" does not exists in the database") 
        {
            
        }
    }
}
