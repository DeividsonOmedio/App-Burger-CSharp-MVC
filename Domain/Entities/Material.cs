using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
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