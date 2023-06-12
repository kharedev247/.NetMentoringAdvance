namespace Task1.DAL.Entities
{
    public class Cart
    {
        public string Id { get; set; }

        public List<Product> CartItems { get; set; }
    }
}
