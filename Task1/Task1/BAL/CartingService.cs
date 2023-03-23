using Task1.Models;

namespace Task1.BAL;

public class CartingService : ICartingService
{
    private readonly ICartingRepository _cartingRepository;

    public CartingService(ICartingRepository cartingRepository)
    {
        _cartingRepository = cartingRepository;
    }

    public void Add(string cartId, Product product)
    {
        if (ValidationService.IsValidProduct(product))
        {
            _cartingRepository.Add(cartId, product);
        }
    }

    public void Remove(string cartId, Product product)
    {
        if (ValidationService.IsValidProduct(product))
        {
            _cartingRepository.Remove(cartId, product);
        }
    }

    public List<Product> GetProducts(string cartId)
    {
        return _cartingRepository.GetProducts(cartId);
    }
}