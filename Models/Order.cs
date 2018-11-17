using Chuska.Models;
using System;

namespace Chushka.Models
{
    public class Order
    {
        public int Id { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public ChushkaUser Client { get; set; }
        public DateTime OrderedOn { get; set; }
    }
}