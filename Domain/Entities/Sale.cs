using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Sale
    {
        [key]
        public int Id { get; set; }

        [Required]
        public DateTime SaleDate { get; set; }

        public string Client { get; set; }

        [Required]
        public decimal TotalValue { get; set; }

        [Required]
        public EnumTypePayment TypePayment { get; set; }

        [Required]
        public EnumStatusSale StatusSale { get; set; }

        [Required]
        public EnumStatusPayment StatusPayment { get; set; }

        public decimal? Discount { get; set; }

    }
}
