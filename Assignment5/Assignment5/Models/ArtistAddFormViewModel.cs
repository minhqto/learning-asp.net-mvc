using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment5.EntityModels;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Assignment5.Models
{ 
    public class ArtistAddFormViewModel
    {
        [Key]
        public int ArtistId { get; set; }
        [Display(Name="Artist name or stage name")]
        public string Name { get; set; }
        [Display(Name = "if applicable, artist's birth name")]
        public string BirthName { get; set; }
        [Display(Name = "Birth date, or start date")]
        [DataType(DataType.Date)]
        public DateTime BirthOrStartDate { get; set; }
        public string Executive { get; set; }
        
        [Display(Name = "URL to artist photo")]
        public string UrlArtist { get; set; }
        [Display(Name="Artist's Primary Genre")]
        public SelectList Genres { get; set; }
    }
}