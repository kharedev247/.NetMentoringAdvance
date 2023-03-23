using Microsoft.EntityFrameworkCore;

namespace Task2.DAL.Context;

public class CatalogDbContext : DbContext
{
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
    {
        
    }

    public DbSet<Entities.Product> Products { get; set; }
    public DbSet<Entities.Category> Categories { get; set; }
}