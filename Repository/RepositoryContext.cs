using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new FoodConfiguration());
            modelBuilder.ApplyConfiguration(new FoodCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewerConfiguration());


            modelBuilder.Entity<FoodCategory>()
                .HasKey(fc => new { fc.FoodId, fc.CategoryId });

            modelBuilder.Entity<FoodCategory>()
                .HasOne(f => f.Food)
                .WithMany(fc => fc.FoodCategories)
                .HasForeignKey(f => f.FoodId);

            modelBuilder.Entity<FoodCategory>()
                .HasOne(f => f.Category)
                .WithMany(fc => fc.FoodCategories)
                .HasForeignKey(f => f.CategoryId);
        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Country>? Countries { get; set; }
        public DbSet<Food>? Foods { get; set; }
        public DbSet<FoodCategory>? FoodCategory {  get; set; }  
        public DbSet<Review>? Reviews { get; set; }
        public DbSet<Reviewer>? Reviewevers { get; set; }
    }
}
