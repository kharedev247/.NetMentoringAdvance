using Microsoft.EntityFrameworkCore;

namespace Task1.DAL.Context;

public class CatalogDbContext : DbContext
{
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
    {
        
    }

    public DbSet<Entities.Product> Products { get; set; }
    public DbSet<Entities.Category> Categories { get; set; }
    public DbSet<Entities.Cart> Carts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entities.Product>();
        modelBuilder.Entity<Entities.Category>();
    }
}