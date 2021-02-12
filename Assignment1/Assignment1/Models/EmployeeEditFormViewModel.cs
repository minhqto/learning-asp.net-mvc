using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure.Design;
using System.Linq;
using System.Web;

namespace Assignment1.Models
{
    // for GET
    public class EmployeeEditFormViewModel
    {
        public EmployeeEditFormViewModel()
        {

        }

        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [StringLength(70)]
        public string Address { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(40)]
        public string State { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [StringLength(60)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }


        [RegularExpression("[0-9]+")]
        [StringLength(9)]
        [Display(Name = "Social Insurance Number")]
        public string SocialInsuranceNumber { get; set; }

        [Range(1, 5)]
        [Display(Name = "Office Level")]
        public int OfficeLevel { get; set; }


    }
}