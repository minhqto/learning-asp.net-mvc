﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment1.Models
{
    public class EmployeeAddViewModel
    {
        public EmployeeAddViewModel()
        {
            DateTime currTime = DateTime.Now;
            this.BirthDate = currTime.AddYears(-20);
        }

        [Required]
        [StringLength(20)]
        [Display(Name="Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string Title { get; set; }

        [Display(Name="Employee date of birth")]
        public DateTime? BirthDate { get; set; }

        [Display(Name="Hire Date")]
        public DateTime? HireDate { get; set; }

        [StringLength(70)]
        public string Address { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(40)]
        public string State { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [StringLength(10)]
        [Display(Name="Postal Code")]
        public string PostalCode { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [StringLength(60)]
        public string Email { get; set; }

    }
}