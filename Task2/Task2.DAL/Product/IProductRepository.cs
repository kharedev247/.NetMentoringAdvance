using Task2.DAL.Entities;

namespace Task2.DAL.Product;
public interface IProductRepository
{
    void Add(Entities.Product product);
    void Update(Entities.Product product);
    void Delete(string name);
    List<Entities.Product> GetAll();
    List<Entities.Product> GetByCategoryId(int categoryId);
    Entities.Product GetByName(string name);
}