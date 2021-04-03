using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Assignment5.EntityModels;

namespace Assignment5.Models
{
    public class TrackBaseViewModel
    {
        [Key]
        public int TrackId { get; set; }
        [Display(Name="Clerk who helps with album tasks")]
        public string Clerk { get; set; }
        [Display(Name="Composer name(s)")]
        public string Composers { get; set; }
        [Display(Name="Track Genre")]
        public string Genre { get; set; }
        [Display(Name="Track Name")]
        public string Name { get; set; }
    }
}