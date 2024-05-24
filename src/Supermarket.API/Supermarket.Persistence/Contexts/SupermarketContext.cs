using Microsoft.EntityFrameworkCore;
using Supermarket.Core.Entities;

namespace Supermarket.Persistence.Contexts
{
    public class SupermarketContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public SupermarketContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // category
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Category>().HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            // product
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();
        }
    }
}
