using Task1.Models;

namespace Task1.BAL;

public class ValidationService
{
    public static bool IsValidProduct(Product product)
    {
        if (product.Id <= 0 || string.IsNullOrEmpty(product.Image) || product.Price <= 0 || product.Quantity <= 0)
        {
            return false;
        }

        return true;
    }
}