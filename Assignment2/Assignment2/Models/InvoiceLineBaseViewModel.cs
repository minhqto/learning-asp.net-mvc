using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assignment2.EntityModels;

namespace Assignment2.Models
{
    public class InvoiceLineBaseViewModel
    {
        [Display(Name="Invoice Line ID")]
        public int InvoiceLineId { get; set; }

        public int InvoiceId { get; set; }
        [Display(Name="Track ID")]
        public int TrackId { get; set; }
        [Display(Name="Unit Price")]
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public Invoice Invoice { get; set; }

        public Track Track { get; set; }

        public decimal LineItemTotal
        {
            get { return Quantity * UnitPrice; }
        }

    }
}