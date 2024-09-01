using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Generic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
