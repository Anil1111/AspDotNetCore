using Chushka.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CHUSHKA.Web.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(Product product)
        {
            this.Name = product.Name;
            this.Id = product.Id;
            this.Description = product.Description;
            this.Price = product.Price;
            this.Type = product.Type;
        }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Name { get; set; }

        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Description { get; set; }

        public string ShortDescription
        {
            get
            {
                if (this.Description.Length > 50)
                {
                    return $"{this.Description.Substring(0, 50)}...";
                }
                return this.Description;
            }
        }

        [Required]
        [Range(0, (double)decimal.MaxValue)]
        public decimal Price { get; set; }

        public string PriceString
        {
            get
            {
                return $"$ {this.Price.ToString("G29")}";
            }
        }

        [Required]
        public ProductType Type { get; set; }
    }
}