using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.ViewModels
{
    public class EventuresEventViewModel
    {
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Place { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [DisplayName("Total tickets")]
        [Range(0, (double)int.MaxValue)]
        public int TotalTickets { get; set; }

        [DisplayName("Ticket price")]
        [Range(0, (double)decimal.MaxValue)]
        public decimal TicketPrice { get; set; }
    }
}