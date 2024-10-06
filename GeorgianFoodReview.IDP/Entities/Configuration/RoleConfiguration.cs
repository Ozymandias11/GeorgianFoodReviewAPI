using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeorgianFoodReview.IDP.Entities.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new IdentityRole
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Id = "c3a0cb55-ddaf-4f2f-8419-f3f937698aa1"
            },
            new IdentityRole
            {
                Name = "Visitor",
                NormalizedName = "VISITOR",
                Id = "6d506b42-9fa0-4ef7-a92a-0b5b0a123665"
            });
        }
    }
}
