using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.DtosForPost
{
    public record ReviewerForCreationDto
    {
        [Required(ErrorMessage = "FirstName is a required field")]
        public string? FirstName { get; init; }
        [Required(ErrorMessage = "LastName is a required field")]
        public string? LastName { get; init; }
    }
}
