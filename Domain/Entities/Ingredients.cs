using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities
{
    [Table("Ingredients")]
    public class Ingredients // ingredientes de cada produto
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int MaterialId { get; set; }
        public Material Material { get; set; } = null!;
        
        public decimal Amount { get; set; }
    }
}