namespace Task1.Models;

public class Response
{
    public dynamic Body { get; set; }
    public string Error { get; set; }

    public List<Link> Links { get; set; } = new List<Link>();
}