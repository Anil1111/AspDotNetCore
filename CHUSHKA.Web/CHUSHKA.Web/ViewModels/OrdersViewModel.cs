using System;

namespace CHUSHKA.Web.ViewModels
{
    public class OrdersViewModel
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string ClientName { get; set; }
        public DateTime OrderedOn { get; set; }
    }
}