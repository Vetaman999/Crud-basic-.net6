using Microsoft.EntityFrameworkCore;
using prueba.Domain.Models;
using prueba.Extensions;
using System.Data;

namespace prueba.Domain.Percistence.Context
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        { 
        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(u => u.ProductId);
            builder.Entity<Product>().Property(u => u.ProductId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(u => u.Name).IsRequired().HasMaxLength(40);
            builder.Entity<Product>().Property(u => u.Description).IsRequired().HasMaxLength(200);
            builder.Entity<Product>().Property(u => u.Price).IsRequired();
            builder.Entity<Product>().Property(u => u.ExpirationDate).IsRequired();
            builder.Entity<Product>().Property(u => u.PublishedAt).IsRequired();

            builder.ApplySnakeCaseNamingConvention();
        }
    }
}
