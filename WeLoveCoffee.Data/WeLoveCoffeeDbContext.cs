using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WeLoveCoffee.Data.EntityModels;

namespace WeLoveCoffee.Data
{
    public class WeLoveCoffeeDbContext : DbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Roast> Roasts { get; set; }
        DbSet<ProductType> ProductTypes { get; set; }
        DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var cbs = new SqliteConnectionStringBuilder
            {
                DataSource = "WeLoveCoffee.db"
            };
            //"Filename=WeLoveCoffee.db"
            optionsBuilder.UseSqlite(cbs.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder
                .Entity<Product>()
                .HasOne(r => r.Roast)
                .WithMany(p => p.Products)
                .HasForeignKey(r => r.RoastId);

            modelBuilder
                .Entity<Product>()
                .HasOne(p => p.ProductType)
                .WithMany(l => l.Products)
                .HasForeignKey(p => p.ProductTypeId);
        }
    }
}
