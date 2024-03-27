using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.DtosForPost
{
    public record CategoryToCreateDto
    {
        [Required(ErrorMessage = "Category Name is a required field")]
        public string? name { get; init; }
    }
}
