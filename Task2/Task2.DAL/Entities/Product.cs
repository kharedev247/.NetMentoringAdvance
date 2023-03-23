namespace Task2.DAL.Entities;

public class Product
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public Category Category { get; set; }
    public int Price { get; set; }
    public int Amount { get; set; }
}