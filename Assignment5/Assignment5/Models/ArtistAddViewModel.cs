using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment5.EntityModels;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Assignment5.Models
{
    public class ArtistAddViewModel
    {
        [Key]
        [Required]
        public int ArtistId { get; set; }
        [Required]
        public string BirthName { get; set; }
        [Required]
        public DateTime BirthOrStartDate { get; set; }
        [Required]
        public string Executive { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UrlArtist { get; set; }
        [Required]
        public string Genre { get; set; }


    }
}