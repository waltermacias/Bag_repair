using Bag_repair.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bag_repair.API.Data
{
     public class DataContext : DbContext
     {
          public DataContext(DbContextOptions<DataContext> options) : base(options)
          {
          }

          public DbSet<ProductType> ProductTypes { get; set; }

          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
               base.OnModelCreating(modelBuilder);
               modelBuilder.Entity<ProductType>().HasIndex(x => x.Description).IsUnique();
          }

     }
}
