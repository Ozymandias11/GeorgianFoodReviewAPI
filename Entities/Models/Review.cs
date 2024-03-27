using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public  class Review
    {
        [Column("ReviewId")]
        public Guid id { get; set; }
        [Required(ErrorMessage = "Review should contain the title")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Review Should contain the description")]
        public string? Description { get; set; }    
        public double? rating { get; set; }

        [ForeignKey(nameof(Reviewever))]
        public Guid RevieweverId { get; set; }  
        public Reviewer? Reviewever { get; set; }

        [ForeignKey(nameof(Food))]
        public Guid FoodId { get; set; }    
        public Food? Food { get; set; }
    }
}
