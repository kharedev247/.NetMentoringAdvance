using Microsoft.EntityFrameworkCore;
using Task2.DAL.Context;

namespace Task2.DAL.Category;

public class CategoryRepository : ICategoryRepository
{
    private readonly CatalogDbContext _context;

    // DBContext should be configured in startup, but as we are focus on BAL and DAL here,
    // so setting it up in constructor
    public CategoryRepository()
    {
        var optionsBuilder = new DbContextOptionsBuilder<CatalogDbContext>();
        optionsBuilder.UseSqlServer("connection_string");

        _context = new CatalogDbContext(optionsBuilder.Options);
    }

    public void Add(Entities.Category category)
    {
        _context.Categories.Add(category);
    }

    public void Update(Entities.Category category)
    {
        _context.Categories.Update(category);
    }

    public void Delete(string name)
    {
        var category = _context.Categories.FirstOrDefault(x => x.Name == name);
        if (category != null)
        {
            _context.Categories.Remove(category);
        }
    }

    public List<Entities.Category> GetAll()
    {
        return _context.Categories.ToList();
    }

    public Entities.Category GetByName(string name)
    {
        return _context.Categories.FirstOrDefault(x => x.Name == name);
    }
}