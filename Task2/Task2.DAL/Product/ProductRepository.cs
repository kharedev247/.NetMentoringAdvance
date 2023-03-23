using Microsoft.EntityFrameworkCore;
using Task2.DAL.Context;

namespace Task2.DAL.Product;

public class ProductRepository : IProductRepository
{
    private readonly CatalogDbContext _context;

    // DBContext should be configured in startup, but as we are focus on BAL and DAL here,
    // so setting it up in constructor
    public ProductRepository()
    {
        var optionsBuilder = new DbContextOptionsBuilder<CatalogDbContext>();
        optionsBuilder.UseSqlServer("connection_string");

        _context = new CatalogDbContext(optionsBuilder.Options);

    }

    public void Add(Entities.Product product)
    {
        _context.Products.Add(product);
    }

    public void Update(Entities.Product product)
    {
        _context.Products.Update(product);
    }

    public void Delete(string name)
    {
        var product = _context.Products.FirstOrDefault(x => x.Name == name);
        if (product != null)
        {
            _context.Products.Remove(product);
        }
    }

    public List<Entities.Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public Entities.Product GetByName(string name)
    {
        return _context.Products.FirstOrDefault(x => x.Name == name);
    }
}