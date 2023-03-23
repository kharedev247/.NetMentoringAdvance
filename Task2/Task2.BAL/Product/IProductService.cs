using Task2.DAL.Entities;

public interface IProductService
{
    void AddProduct(Product product);
    void DeleteProduct(string name);
    List<Product> ListProducts();
    Product GetProduct(string name);
    void UpdateProduct(Product product);
}