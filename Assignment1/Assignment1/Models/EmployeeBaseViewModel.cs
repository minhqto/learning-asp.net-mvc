using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Assignment1.Models
{
    public class EmployeeBaseViewModel : EmployeeAddViewModel
    {
        public EmployeeBaseViewModel()
        {
          
            
        }
        [Key]
        [Display(Name="Employee ID")]
        public int EmployeeId { get; set; }
    }
}