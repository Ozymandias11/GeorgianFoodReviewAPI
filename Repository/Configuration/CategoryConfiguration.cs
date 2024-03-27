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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(

                  new Category
                  {
                      CategoryId = new Guid("67a7885e-af6e-4c84-ad28-3067c9353a97"),
                      Name = "Meat dishes"
                  },
                  new Category
                  {
                      CategoryId = new Guid("9b95349a-ebd6-4eea-a56e-c761975aac3c"),
                      Name = "Wine"
                  },
                   new Category
                   {
                       CategoryId = new Guid("ac0627cc-470c-4772-8d5d-9bc9f74d543a"),
                       Name = "Cheese"
                   }


                );
        }
    }
}
