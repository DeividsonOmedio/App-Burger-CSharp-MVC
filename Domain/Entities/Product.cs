﻿using Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public EnumCategoryProducts Category { get; set; }
        
        public string Image { get; set; }

    }
}
