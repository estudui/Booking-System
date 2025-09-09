using BookSystemApi.Dto.Division;
using BookSystemApi.Dto.Product;
using BookSystemApi.Dto.User;
using BookSystemApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookSystemApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional configuration can go here

            modelBuilder.Entity<ProductResponseNew>().HasNoKey();
            modelBuilder.Entity<DivisionDto>().HasNoKey();
            modelBuilder.Entity<UserAuthDto>().HasNoKey();
        }

        public DbSet<Product> Products { get; set; }
    }
}