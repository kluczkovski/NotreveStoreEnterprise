using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NSE.Catalogue.API.Models;

namespace NSE.Catalogue.API.Data
{
    public class CatalogueContext : DbContext
    {
        public CatalogueContext(DbContextOptions<CatalogueContext> options) :base(options)
        {
        }

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                    e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");
          
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogueContext).Assembly);
        }
    }
}
