using Task2.BAL.Validators;

namespace Task2.BAL.Category;

public class CategoryService : ICategoryService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository, IProductRepository productRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public void AddCategory(DAL.Entities.Category category)
    {
        if (CategoryValidator.IsValidCategory(category))
        {
            _categoryRepository.Add(category);
        }
    }

    public void DeleteCategory(string name)
    {
        var products = _productRepository.GetAll().Where(x => x.Category.Name == name);
        foreach (var product in products)
        {
            _productRepository.Delete(product.Name);
        }

        _categoryRepository.Delete(name);
    }

    public List<DAL.Entities.Category> ListCategories()
    {
        return _categoryRepository.GetAll();
    }

    public DAL.Entities.Category GetCategory(string name)
    {
        return _categoryRepository.GetByName(name);
    }

    public void UpdateCategory(DAL.Entities.Category category)
    {
        if (CategoryValidator.IsValidCategory(category))
        {
            _categoryRepository.Update(category);
        }
    }
}