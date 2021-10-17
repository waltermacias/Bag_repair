using Bag_repair.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bag_repair.API.Data
{
     public class DataContext : DbContext
     {
          public DataContext(DbContextOptions<DataContext> options) : base(options)
          { 
          }

          public DbSet<ProductTypes> ProductTypes { get; set; }

          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
               base.OnModelCreating(modelBuilder);
               modelBuilder.Entity<ProductTypes>().HasIndex(x => x.Description).IsUnique();
          }

     }
}
