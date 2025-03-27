using Microsoft.EntityFrameworkCore;
using WebApplication56.Models;

namespace WebApplication56.Data
{
    public class BestStoreContext : DbContext
    {
        public BestStoreContext(DbContextOptions<BestStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("Products", schema: "dbo");

            modelBuilder.Entity<Category>()
                .ToTable("Categories", schema: "dbo");

            modelBuilder.Entity<Brand>()
                .ToTable("Brands", schema: "dbo");

            // Configure relationships
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 