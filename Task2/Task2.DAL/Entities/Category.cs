namespace Task2.DAL.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public string ParentCategory { get; set; }
}