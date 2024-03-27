using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
   public class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(Guid categoryId) : base($"The category with id {categoryId}" +
            $" does not exist in the database")
        {
            
        }
    }
}
