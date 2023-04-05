using Microsoft.EntityFrameworkCore;
using Task2.DAL.Context;

namespace Task2.DAL.Category;

public class CategoryRepository : ICategoryRepository
{
    private readonly CatalogDbContext _context;

    public CategoryRepository(CatalogDbContext context)
    {
        _context = context;
    }

    public void Add(Entities.Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public void Update(Entities.Category category)
    {
        _context.Categories.Update(category);
        _context.SaveChanges();
    }

    public void Delete(string name)
    {
        var category = _context.Categories.FirstOrDefault(x => x.Name == name);
        if (category != null)
        {
            _context.Categories.Remove(category);
        }

        _context.SaveChanges();
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