using LiteDB;
using Task1.BAL;
using Task1.Models;

namespace Task1.DAL;

public class CartingRepository : ICartingRepository
{
    private readonly LiteDatabase _database;

    public CartingRepository()
    {
        _database = new LiteDatabase("Cart.db");
    }

    public void Add(string cartId, Product product)
    {
        var carts = _database.GetCollection<Cart>("carts");
        
        var cart = carts.Find(x => x.Id == cartId).FirstOrDefault();

        cart?.Products.Add(product);

        if (cart != null)
        {
            carts.Update(cart);
        }
    }

    public void Remove(string cartId, Product product)
    {
        var carts = _database.GetCollection<Cart>("carts");

        var cart = carts.Find(x => x.Id == cartId).FirstOrDefault();

        cart?.Products.Remove(product);

        if (cart != null)
        {
            carts.Update(cart);
        }
    }

    public List<Product> GetProducts(string cartId)
    {
        var carts = _database.GetCollection<Cart>("carts");
        
        var cart = carts.Find(x => x.Id == cartId).FirstOrDefault();

        return cart?.Products;
    }
}