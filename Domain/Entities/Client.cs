using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Clients")]
    public class Client : Generic
    {
        public string Email { get; set; }

        [Required]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        public DateOnly DataBirth { get; set; }

        [Required]
        public DateTime RegisteredIn { get; set; }
    }
}
