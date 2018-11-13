using System.ComponentModel.DataAnnotations;

namespace Chushka.Data
{
    public enum Type
    {
        Food,
        Health,
        Cosmetic,
        Other,
        Domestic
    }

    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Type Type { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}