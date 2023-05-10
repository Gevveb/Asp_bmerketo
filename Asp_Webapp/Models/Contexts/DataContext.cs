using Asp_Webapp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Asp_Webapp.Models.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>().HasData(
                new { Id = 1, CategoryName = "new" },
                new { Id = 2, CategoryName = "popular" },
                new { Id = 3, CategoryName = "featured" }
            );
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ContactFormEntity> ContactForms { get; set; }

        //public DbSet<ProductEntity> Products { get; set; }
        //public DbSet<ProductCategoryEntity> ProductCategories  { get; set; }
    }
}
