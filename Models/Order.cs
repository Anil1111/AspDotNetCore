using Chuska.Models;
using System;

namespace Chushka.Models
{
    public class Order
    {
        public string Id { get; set; }
        public virtual Product Product { get; set; }
        public string ProductId { get; set; }
        public ChushkaUser Client { get; set; }
        public DateTime OrderedOn { get; set; }
    }
}