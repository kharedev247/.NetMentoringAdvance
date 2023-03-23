namespace Task2.BAL.Validators;

public class ProductValidator
{
    public static bool IsValidProduct(DAL.Entities.Product product)
    {
        if (string.IsNullOrEmpty(product.Name) || product.Category == null || product.Price <= 0 || product.Amount <= 0)
        {
            return false;
        }

        return true;
    }
}