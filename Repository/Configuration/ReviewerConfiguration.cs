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
    public class ReviewerConfiguration : IEntityTypeConfiguration<Reviewer>
    {
        public void Configure(EntityTypeBuilder<Reviewer> builder)
        {
            builder.HasData(
                  new Reviewer
                  {
                      Id = new Guid("fd04a33c-72cd-4de3-ab12-da2688c575c2"), 
                      FirstName = "John",
                      LastName = "Doe",
                      CountryId = new Guid("6fd5d92b-420d-4d73-961f-e331428a0203")
              
                  },
                   new Reviewer
                   {
                       Id = new Guid("707c77e5-c93f-4156-ad70-3f59a0395c48"),
                       FirstName = "Jane",
                       LastName = "Smith",
                       CountryId = new Guid("6fd5d92b-420d-4d73-961f-e331428a0203")

                   },
                    new Reviewer
                    {
                        Id = new Guid("2d59d738-4c67-4221-87b0-afb48d04db10"),
                        FirstName = "Michael",
                        LastName = "Johnson",
                        CountryId = new Guid("7a803201-2cde-40ab-92d9-64f0c3293658")

                    }
                );
        }
    }
}
