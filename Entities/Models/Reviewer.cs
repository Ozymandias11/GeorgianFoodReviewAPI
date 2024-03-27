using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Reviewer
    {
        [Column("RevieweverId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "firstname is a required field")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "lastname is a required field")]
        public string? LastName { get; set; }    
        public ICollection<Review>? Reviews { get; set; }

        [ForeignKey(nameof(Country))]
        public Guid CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
