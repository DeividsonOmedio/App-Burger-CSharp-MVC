namespace Mvc.Models
{
    public class Product : Generic
    {
        public Guid Code { get; set; }
        public int? Amount { get; set; }
        public decimal Price { get; set; }
        public List<string> Ingredients { get; set; }
    }
}
