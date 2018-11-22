using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventures.Models
{
    public class EventuresEvent
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int TotalTickets { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, (double)decimal.MaxValue)]
        public decimal TicketPrice { get; set; }
    }
}