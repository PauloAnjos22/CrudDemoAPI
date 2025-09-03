namespace CrudDemoAPI.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
