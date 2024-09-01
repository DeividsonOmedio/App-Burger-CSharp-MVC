using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
