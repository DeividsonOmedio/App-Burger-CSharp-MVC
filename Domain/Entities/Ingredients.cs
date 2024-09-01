using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Ingredients")]
    public class Ingredients
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public decimal Amount { get; set; }
    }
}