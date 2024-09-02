using Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Employees")]
    public class Employee : Generic
    {
        [Required]
        [MaxLength(20)]
        public string User { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;

        public EnumFunctionEmployee Function { get; set; }
    }
}
