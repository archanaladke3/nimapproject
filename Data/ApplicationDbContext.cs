using Microsoft.EntityFrameworkCore;
using Nimap_project.Models;

namespace Nimap_project.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {


        }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships between entities if needed
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);
        }


    }
}
