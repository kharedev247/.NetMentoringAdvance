using Task2.DAL.Entities;

namespace Task2.BAL.Category;
public interface ICategoryService
{
    void AddCategory(DAL.Entities.Category category);
    void DeleteCategory(string name);
    List<DAL.Entities.Category> ListCategories();
    DAL.Entities.Category GetCategory(string name);
    void UpdateCategory(DAL.Entities.Category category);
}