using Task1.BAL.Validators;

namespace Task1.BAL.Product;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void AddProduct(DAL.Entities.Product product)
    {
        if (ProductValidator.IsValidProduct(product))
        {
            _productRepository.Add(product);
        }
    }

    public void DeleteProduct(string name)
    {
        _productRepository.Delete(name);
    }

    public List<DAL.Entities.Product> ListProducts()
    {
        return _productRepository.GetAll();
    }

    public List<DAL.Entities.Product> ListProductsByCategoryId(int categoryId)
    {
        return _productRepository.GetByCategoryId(categoryId);
    }

    public DAL.Entities.Product GetProduct(string name)
    {
        return _productRepository.GetByName(name);
    }

    public void UpdateProduct(DAL.Entities.Product product)
    {
        if (ProductValidator.IsValidProduct(product))
        {
            _productRepository.Update(product);
        }
    }
}