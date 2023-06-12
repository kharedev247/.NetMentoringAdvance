using Task2.DAL.Entities;

namespace Task2.DAL.Category;

public interface ICategoryRepository
{
    void Add(Entities.Category category);
    void Update(Entities.Category category);
    void Delete(string name);
    List<Entities.Category> GetAll();
    Entities.Category GetByName(string name);
}