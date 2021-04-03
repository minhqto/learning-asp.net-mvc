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
        [Required]
        public int ArtistId { get; set; }
        [Required]
        [Display(Name="Artist name or stage name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "if applicable, artist's birth name")]
        public string BirthName { get; set; }
        [Required]
        [Display(Name = "Birth date, or start date")]
        [DataType(DataType.Date)]
        public DateTime BirthOrStartDate { get; set; }
        public string Executive { get; set; }
        [Required]
        [Display(Name = "URL to artist photo")]
        public string UrlArtist { get; set; }
        [Required]
        [Display(Name="Artist's Primary Genre")]
        public SelectList Genres { get; set; }
    }
}