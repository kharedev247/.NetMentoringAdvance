using Task1.DAL.Cart;

namespace Task1.BAL.Cart
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public DAL.Entities.Cart GetCartInfo(string cartId)
        {
            return _cartRepository.GetCartInfo(cartId);
        }

        public void AddItemToCart(string cartId, DAL.Entities.Product cartItem)
        {
            var cart = _cartRepository.GetCartInfo(cartId);
            _cartRepository.AddItemsToCart(cart.Id, cartItem);
        }

        public void DeleteItemFromCart(string cartId, int itemId)
        {
            _cartRepository.DeleteItemsFromCart(cartId, itemId);
        }

        public List<DAL.Entities.Product> GetCartItems(string cartId)
        {
           return _cartRepository.GetCartItems(cartId);
        }

        public void UpdateItemsForAllCart(DAL.Entities.Product product)
        {
            _cartRepository.UpdateItemForAllCarts(product);
        }
    }
}
