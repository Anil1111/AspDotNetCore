using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chushka.Data
{
    public class Order
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public User Client { get; set; }

        [Required]
        public IEnumerable<Product> Product { get; set; }

        [Required]
        public DateTime OrderedOn { get; set; }
    }
}