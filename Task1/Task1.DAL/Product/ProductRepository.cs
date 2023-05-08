using Microsoft.EntityFrameworkCore;
using Task1.DAL.Context;

namespace Task1.DAL.Product;

public class ProductRepository : IProductRepository
{
    private readonly CatalogDbContext _context;

    public ProductRepository(CatalogDbContext context)
    {
        _context = context;
    }

    public void Add(Entities.Product product)
    {
        _context.Product.Add(product);
        _context.SaveChanges();
    }

    public void Update(Entities.Product product)
    {
        _context.Product.Update(product);
        _context.SaveChanges();
    }

    public void Delete(string name)
    {
        var product = _context.Product.FirstOrDefault(x => x.Name == name);
        if (product != null)
        {
            _context.Product.Remove(product);
        }
        _context.SaveChanges();
    }

    public List<Entities.Product> GetAll()
    {
        return _context.Product.ToList();
    }

    public List<Entities.Product> GetByCategoryId(int categoryId)
    {
        return _context.Product.Where(p => p.Category.Id == categoryId).ToList();
    }

    public Entities.Product GetByName(string name)
    {
        return _context.Product.FirstOrDefault(x => x.Name == name);
    }
}