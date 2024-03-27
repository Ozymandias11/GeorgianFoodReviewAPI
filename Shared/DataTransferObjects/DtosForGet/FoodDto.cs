using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.DtosForGet
{
    public record FoodDto(Guid id, string name, string description);
}
