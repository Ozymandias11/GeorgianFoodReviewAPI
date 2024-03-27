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
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasData(
                new Food
                {
                    Id = new Guid("8a852b0f-7b79-48ab-912d-e3d05602df56"),
                    Name = "Chakhokhbili",
                    Description = "Chakhokhbili is a traditional Georgian dish made with chicken simmered in a flavorful tomato-based sauce."

                },
                 new Food
                 {
                     Id = new Guid("65ccc9a6-ed7b-4527-b4bd-cb7151d9ff0f"),
                     Name = "Khinkali",
                     Description = "Khinkali is a traditional Georgian dumpling known for its savory filling and unique pleated shape."

                 },
                  new Food
                  {
                      Id = new Guid("27f794a5-9aaa-46c9-bca4-10eee5f75e72"),
                      Name = "Khachapuri",
                      Description = "Khachapuri is a quintessential Georgian dish that has gained international acclaim for its irresistible combination of cheese-filled bread."

                  }

                );
        }
    }
}
