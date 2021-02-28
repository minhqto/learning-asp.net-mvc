using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Assignment2.EntityModels;

namespace Assignment2.Models
{
    public class InvoiceWithDetailViewModel : InvoiceBaseViewModel
    {
        [Display(Name="Customer Name")]
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        
        [Display(Name="Sales Representative")]
        public string CustomerEmployeeFirstName { get; set; }
        public string CustomerEmployeeLastName { get; set; }
        public IEnumerable<InvoiceLineWithDetailViewModel> InvoiceLines { get; set; }

    }
}