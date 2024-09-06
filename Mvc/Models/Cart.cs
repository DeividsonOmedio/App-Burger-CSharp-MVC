namespace Mvc.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Amount { get; set; }
        public decimal TotalPrice { get; set; }
        public string Observation { get; set; }
        public int ClientId { get; set; }
    }
}
