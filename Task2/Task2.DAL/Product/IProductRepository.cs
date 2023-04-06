using Task2.DAL.Entities;

public interface IProductRepository
{
    void Add(Product product);
    void Update(Product product);
    void Delete(string name);
    List<Product> GetAll();
    List<Product> GetByCategoryId(int categoryId);
    Product GetByName(string name);
}