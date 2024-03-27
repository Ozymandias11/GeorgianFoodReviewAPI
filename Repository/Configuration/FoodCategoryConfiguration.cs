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
    public class FoodCategoryConfiguration : IEntityTypeConfiguration<FoodCategory>
    {
        public void Configure(EntityTypeBuilder<FoodCategory> builder)
        {
            builder.HasData(

                // chakokhbili - Meat Dishes
                new FoodCategory
                {
                    FoodId = new Guid("8a852b0f-7b79-48ab-912d-e3d05602df56"),
                    CategoryId = new Guid("67a7885e-af6e-4c84-ad28-3067c9353a97")
                },
                //Khinkali - Meatdishes
                new FoodCategory
                {
                    FoodId = new Guid("65ccc9a6-ed7b-4527-b4bd-cb7151d9ff0f"),
                    CategoryId = new Guid("67a7885e-af6e-4c84-ad28-3067c9353a97")
                },
                //Khachapuri - cheese
                new FoodCategory
                {
                    FoodId = new Guid("27f794a5-9aaa-46c9-bca4-10eee5f75e72"),
                    CategoryId = new Guid("ac0627cc-470c-4772-8d5d-9bc9f74d543a")
                }
                );
        }
    }
}
