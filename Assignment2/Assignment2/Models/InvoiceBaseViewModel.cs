using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assignment2.EntityModels;

namespace Assignment2.Models
{
    public class InvoiceBaseViewModel
    {
        public InvoiceBaseViewModel() { }
        [Key]
        [Required]
        [Display(Name="Invoice ID")]
        public int InvoiceId { get; set; }
        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }
        [Display(Name = "Invoice Date")]
        public DateTime InvoiceDate { get; set; }

        [Display(Name = "Billing Address")]
        [StringLength(70)]
        public string BillingAddress { get; set; }

        [Display(Name = "Billing City")]
        [StringLength(40)]
        public string BillingCity { get; set; }

        [Display(Name = "Billing State")]
        [StringLength(40)]
        public string BillingState { get; set; }

        [Display(Name = "Billing Country")]
        [StringLength(40)]
        public string BillingCountry { get; set; }

        [Display(Name = "Billing Postal Code")]
        [StringLength(10)]
        public string BillingPostalCode { get; set; }

        [Display(Name = "Total")]
        [Column(TypeName = "numeric")]
        public decimal Total { get; set; }

        [Display(Name = "Customer")]
        public Customer Customer { get; set; }

        [Display(Name = "Invoice Lines")]
        public ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}