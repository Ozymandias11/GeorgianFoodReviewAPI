using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class CountryAlreadyExistsException : AlreadyExistsException
    {
        public CountryAlreadyExistsException(string countryName) : 
            base($"The country with name {countryName} Already exists in the database")
        {
            
        }
    }
}
