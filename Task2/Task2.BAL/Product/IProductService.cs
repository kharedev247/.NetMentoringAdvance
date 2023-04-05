using Task2.DAL.Entities;

public interface IProductService
{
    void AddProduct(Product product);
    void DeleteProduct(string name);
    List<Product> ListProducts();
    List<Product> ListProductsByCategoryId(int categoryId);
    Product GetProduct(string name);
    void UpdateProduct(Product product);
}