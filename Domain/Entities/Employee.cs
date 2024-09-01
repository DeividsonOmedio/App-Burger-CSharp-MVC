using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee : Generic
    {
        [Required]
        [MaxLength(20)]
        public string User { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public EnumFunctionEmployee Function { get; set; }
    }
}
