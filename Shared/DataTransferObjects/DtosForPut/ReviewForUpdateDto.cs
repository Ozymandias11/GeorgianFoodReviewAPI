using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.DtosForPut
{
   public record ReviewForUpdateDto(string Title, string Description, double Rating);
}
