using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.DtoForManupulation
{
    public abstract record CategoryForManipulationDto
    {
        [Required(ErrorMessage = "Category Name is a required field")]
        public string? name { get; init; }
    }
}
