using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Products")]
    public class Product : Generic
    {
        [Required]
        public Guid Code { get; set; }

        public int? Amount { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
