namespace Task2.DAL.Cart;

public interface ICartRepository
{
    Entities.Cart GetCartInfo(string cartId);
    Entities.Cart CreateCart(string cartId);
    void AddItemsToCart(string cartId, Entities.Product cartItem);
    void DeleteItemsFromCart(string cartId, int itemId);
    List<Entities.Product> GetCartItems(string cartId);
    void UpdateItemForAllCarts(Entities.Product product);
}