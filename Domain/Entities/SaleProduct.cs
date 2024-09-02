using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    [Table("SaleProduct")]
    public class SaleProduct
    {
            [Key]
            public int Id { get; set; }

            public int SaleId { get; set; }
            public Sale Sale { get; set; } = null!;

            public int ProductId { get; set; }
            public Product Product { get; set; } = null!;

            [Required]
            public int Amount { get; set; }
    }
}
