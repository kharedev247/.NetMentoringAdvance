namespace Task2.BAL.Cart;

public interface ICartService
{
    DAL.Entities.Cart GetCartInfo(string cartId);
    void AddItemToCart(string cartId, DAL.Entities.Product cartItem);
    void DeleteItemFromCart(string cartId, int itemId);
    List<DAL.Entities.Product> GetCartItems(string cartId);
}