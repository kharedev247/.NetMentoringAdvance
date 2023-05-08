using Microsoft.EntityFrameworkCore;
using Task1.DAL.Context;

namespace Task1.DAL.Category;

public class CategoryRepository : ICategoryRepository
{
    private readonly CatalogDbContext _context;

    public CategoryRepository(CatalogDbContext context)
    {
        _context = context;
    }

    public void Add(Entities.Category category)
    {
        _context.Category.Add(category);
        _context.SaveChanges();
    }

    public void Update(Entities.Category category)
    {
        _context.Category.Update(category);
        _context.SaveChanges();
    }

    public void Delete(string name)
    {
        var category = _context.Category.FirstOrDefault(x => x.Name == name);
        if (category != null)
        {
            _context.Category.Remove(category);
        }
        _context.SaveChanges();
    }

    public List<Entities.Category> GetAll()
    {
        return _context.Category.ToList();
    }

    public Entities.Category GetByName(string name)
    {
        return _context.Category.FirstOrDefault(x => x.Name == name);
    }
}