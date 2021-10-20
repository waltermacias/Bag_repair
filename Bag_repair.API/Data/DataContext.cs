using Bag_repair.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bag_repair.API.Data
{
     public class DataContext : DbContext
     {
          public DataContext(DbContextOptions<DataContext> options) : base(options)
          {
          }

          public DbSet<DocumentType> DocumentTypes { get; set; }
          public DbSet<Procedure> Procedures { get; set; }
          public DbSet<ProductType> ProductTypes { get; set; }

          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
               base.OnModelCreating(modelBuilder);
               modelBuilder.Entity<DocumentType>().HasIndex(x => x.Description).IsUnique();
               modelBuilder.Entity<Procedure>().HasIndex(x => x.Description).IsUnique();
               modelBuilder.Entity<ProductType>().HasIndex(x => x.Description).IsUnique();

          }

     }
}
