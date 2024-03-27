using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.DtosForGet
{
    public record ReviewDto(Guid id, string Title, string Description, double rating,
                              string FoodName);
}
