using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.DtoForManupulation
{
   public abstract record FoodForManipulationDto
    {
        [Required(ErrorMessage = "Food Name is a required field")]
        public string? Name { get; init; }
        [StringLength(200, ErrorMessage = "Maximum length Of the  Description is 200 characters.")]
        public string? Description { get; init; }
    }
}
