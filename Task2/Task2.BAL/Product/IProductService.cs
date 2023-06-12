using Task2.DAL.Entities;

namespace Task2.BAL.Product;
public interface IProductService
{
    void AddProduct(DAL.Entities.Product product);
    void DeleteProduct(string name);
    List<DAL.Entities.Product> ListProducts();
    List<DAL.Entities.Product> ListProductsByCategoryId(int categoryId);
    DAL.Entities.Product GetProduct(string name);
    void UpdateProduct(DAL.Entities.Product product);
}