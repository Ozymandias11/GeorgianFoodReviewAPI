using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Country
    {
        [Column("CountryId")]
        public Guid Id {  get; set; }
        [Required(ErrorMessage = "Country is a required field")]
        public string? Name { get; set; }
        public ICollection<Reviewer>? Reviewevers { get; set; }
    }
}
