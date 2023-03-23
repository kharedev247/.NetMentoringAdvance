using Task2.DAL.Entities;

public interface ICategoryService
{
    void AddCategory(Category category);
    void DeleteCategory(string name);
    List<Category> ListCategories();
    Category GetCategory(string name);
    void UpdateCategory(Category category);
}