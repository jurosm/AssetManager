using AssetManager.Domain.Entities;
using Contracts.Database;
using Microsoft.EntityFrameworkCore;

namespace AssetManager.Infrastructure.Database
{
    public class AssetManagerContext : DbContext, IAssetManagerContext
    {
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>().HasOne(a => a.Category).WithMany(c => c.Assets).IsRequired();

            modelBuilder.Entity<Category>().HasMany(c => c.Assets).WithOne(a => a.Category);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:/data/mysqlitedatabase.db");
        }
    }
}
