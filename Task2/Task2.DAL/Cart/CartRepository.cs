using Task2.DAL.Context;

namespace Task2.DAL.Cart
{
    public class CartRepository : ICartRepository
    {
        private readonly CatalogDbContext _context;

        public CartRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public Entities.Cart GetCartInfo(string cartId)
        {
            return _context.Carts.First(x => x.Id == cartId);
        }

        public Entities.Cart CreateCart(string cartId)
        {
            var newCart = new Entities.Cart()
            {
                Id = cartId
            };

            _context.Carts.Add(newCart);
            _context.SaveChanges();
            return newCart;
        }

        public void AddItemsToCart(string cartId, Entities.Product cartItem)
        {
            var cart = _context.Carts.FirstOrDefault(x => x.Id == cartId) ?? CreateCart(cartId);
            cart.CartItems.Add(cartItem);
            _context.SaveChanges();
        }

        public void DeleteItemsFromCart(string cartId, int itemId)
        {
            var cart = GetCartInfo(cartId);
            var product = _context.Products.FirstOrDefault(x => x.Id == itemId);
            if (product != null)
            {
                cart.CartItems.Remove(product);
            }
            _context.SaveChanges();
        }

        public List<Entities.Product> GetCartItems(string cartId)
        {
            return _context.Carts.First(x => x.Id == cartId).CartItems;
        }
    }
}
