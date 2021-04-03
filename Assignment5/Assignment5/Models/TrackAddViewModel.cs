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
        public int TrackId { get; set; }

        public string Clerk { get; set; }
        public string Composers { get; set; }
        public string Genre { get; set; }
        public SelectList GenreList { get; set; }
        public string Name { get; set; }
        public Artist ArtistName { get; set; }
        public int AlbumId { get; set; }
    }
}