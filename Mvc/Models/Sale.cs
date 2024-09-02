using Mvc.Models.Enums;

namespace Mvc.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;

        public decimal TotalValue { get; set; }

        public EnumTypePayment TypePayment { get; set; }

        public EnumStatusSale StatusSale { get; set; }

        public EnumStatusPayment StatusPayment { get; set; }

        public decimal? Discount { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

    }
}
