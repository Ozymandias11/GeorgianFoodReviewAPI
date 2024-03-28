using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.DtoForManupulation
{
    public abstract record CountryForManipulationDto
    {
        [Required(ErrorMessage = "Country Name is a required field")]
        public string? Name { get; init; }
    }
}
