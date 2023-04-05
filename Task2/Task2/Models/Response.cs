namespace Task2.Models;

public class Response
{
    public dynamic Body { get; set; }

    public List<Link> Links { get; set; } = new List<Link>();
}