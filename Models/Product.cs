﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Chushka.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public ProductType Type { get; set; }
    }
}