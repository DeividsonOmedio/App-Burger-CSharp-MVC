namespace Mvc.Models
{
    public class SaleProducts
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public Sale Sale { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public decimal Amount { get; set; }
    }
}
