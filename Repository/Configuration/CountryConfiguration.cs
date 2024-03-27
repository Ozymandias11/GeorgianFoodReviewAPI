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
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country
                {
                    Id = new Guid("6fd5d92b-420d-4d73-961f-e331428a0203"),
                    Name = "United States"
                },
                new Country
                {
                    Id = new Guid("7a803201-2cde-40ab-92d9-64f0c3293658"),
                    Name = "Germany"
                }

                );
        }
    }
}
