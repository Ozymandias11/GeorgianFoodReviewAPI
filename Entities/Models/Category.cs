using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Category
    {
        [Column("categoryId")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        [MaxLength(60, ErrorMessage = "maximum length for the food name is 60 characters")]
        public string? Name { get; set; }
        public ICollection<FoodCategory> FoodCategories { get; set; }
    }
}
