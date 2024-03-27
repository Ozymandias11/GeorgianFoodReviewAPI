using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasData(
                  new Review
                  {
                      id = new Guid("8886de1e-b268-48fb-8473-ecb26efc0ac2"),
                      Title = "Khachapuri description",
                      Description = "Absolutely stunning", 
                      rating = 10,
                      RevieweverId = new Guid("fd04a33c-72cd-4de3-ab12-da2688c575c2"),
                      FoodId = new Guid("27f794a5-9aaa-46c9-bca4-10eee5f75e72")
                      
                  },
                   new Review
                   {
                       id = new Guid("9743e067-fede-46b9-9fbc-bf74cb647c61"),
                       Title = "Khinkali description",
                       Description = "Superb",
                       rating = 10,
                       RevieweverId = new Guid("2d59d738-4c67-4221-87b0-afb48d04db10"),
                       FoodId = new Guid("65ccc9a6-ed7b-4527-b4bd-cb7151d9ff0f")

                   }


                );
        }
    }
}
