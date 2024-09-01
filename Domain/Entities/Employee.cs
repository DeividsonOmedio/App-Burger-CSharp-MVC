using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee : Generic
    {
        public string User { get; set; }
        public string Password { get; set; }
        public EnumFunctionEmployee Function { get; set; }
    }
}
