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
        public int ArtistId { get; set; }
        public string BirthName { get; set; }
        public DateTime BirthOrStartDate { get; set; }
        public string Executive { get; set; }
        public string Name { get; set; }
        public string UrlArtist { get; set; }

        public string Genre { get; set; }


    }
}