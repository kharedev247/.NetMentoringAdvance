using Task1.Models;

namespace Task1.BAL;

public interface ICartingService
{
    void Add(string cartId, Product product);
    void Remove(string cartId, Product product);
    List<Product> GetProducts(string cartId);
}