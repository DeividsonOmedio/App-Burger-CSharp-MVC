
using Mvc.Models.Enums;

namespace Mvc.Models
{
    public class Employee : Generic
    {
        public string User { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public EnumFunctionEmployee Function { get; set; }
    }
}
