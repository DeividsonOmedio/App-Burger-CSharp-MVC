using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Materials")]
    public class Material : Generic
    {
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public decimal MinimumQuantity { get; set; }

        [Required]
        public decimal PurchasePrice { get; set; }

    }
}