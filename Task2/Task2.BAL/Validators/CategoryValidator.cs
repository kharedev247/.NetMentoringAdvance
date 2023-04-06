namespace Task2.BAL.Validators;

public class CategoryValidator
{
    public static bool IsValidCategory(DAL.Entities.Category category)
    {
        if (string.IsNullOrEmpty(category.Name))
        {
            return false;
        }

        return true;
    }
}