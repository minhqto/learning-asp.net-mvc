using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment5.EntityModels;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Assignment5.Models
{
    public class TrackAddViewModel
    {
        [Key]
        [Required]
        public int TrackId { get; set; }
        public string Clerk { get; set; }
        [Required]
        public string Composers { get; set; }
        [Required]
        public string Genre { get; set; }
   
        public SelectList GenreList { get; set; }
        [Required]
        public string Name { get; set; }
   
        public Artist ArtistName { get; set; }

        public int AlbumId { get; set; }
    }
}