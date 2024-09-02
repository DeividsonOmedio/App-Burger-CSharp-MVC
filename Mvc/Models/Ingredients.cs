namespace Mvc.Models
{
    public class Ingredients // ingredientes de cada produto
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int MaterialId { get; set; }
        public Material Material { get; set; } = null!;
        
        public decimal Amount { get; set; }
    }
}
