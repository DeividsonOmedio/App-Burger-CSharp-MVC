using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Sale : Generic
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public string Client { get; set; }
        public decimal TotalValue { get; set; }
        public EnumTypePayment TypePayment { get; set; }
        public EnumStatusSale StatusSale { get; set; }
        public EnumStatusPayment StatusPayment { get; set; }

    }
}
