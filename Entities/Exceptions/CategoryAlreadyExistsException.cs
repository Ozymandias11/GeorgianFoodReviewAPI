using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class CategoryAlreadyExistsException : AlreadyExistsException
    {
        public CategoryAlreadyExistsException(string name) : 
            base($"The category with name {name} already exists")
        {
            
        }
    }
}
