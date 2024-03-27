using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.DtosForPost
{
    public record ReviewForCreationDto
    {
        [Required(ErrorMessage = "Title is a required field")]
        public string? Title { get; init; }
        [StringLength(200, ErrorMessage = "Maximum length Of the  Description is 200 characters.")]
        public string? Description { get; init; }
        [Range(0, 10.0,ErrorMessage = "rating is a required filed and it can't be lower than 0 and " +
            " greater than 10.0")]
        public double rating { get; init; } 
    }
}
