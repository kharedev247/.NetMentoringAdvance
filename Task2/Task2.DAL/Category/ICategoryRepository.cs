using Task2.DAL.Entities;

public interface ICategoryRepository
{
    void Add(Category category);
    void Update(Category category);
    void Delete(string name);
    List<Category> GetAll();
    Category GetByName(string name);
}