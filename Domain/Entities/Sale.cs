using Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Sales")]
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime SaleDate { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;

        [Required]
        public decimal TotalValue { get; set; }

        [Required]
        public EnumTypePayment TypePayment { get; set; }

        [Required]
        public EnumStatusSale StatusSale { get; set; }

        [Required]
        public EnumStatusPayment StatusPayment { get; set; }

        public decimal? Discount { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

    }
}
