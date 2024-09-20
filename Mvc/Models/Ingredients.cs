namespace Mvc.Models
{
    public class Ingredients // ingredientes de cada produto
    {
        public int ProductId { get; set; }
        public string NameProduct { get; set; } = null!;
        public int? AmountProduct { get; set; }
        public decimal PriceProduct { get; set; }
        public Dictionary<string, decimal>? MaterialsProducts { get; set; }
        public int MaterialId { get; set; }
        public List<Material> Materials { get; set; }

        public decimal AmountMaterisal { get; set; }

        public decimal MinimumQuantity { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}
