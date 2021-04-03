using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment5.EntityModels;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Assignment5.Models
{
    public class AlbumAddViewModel
    {
        public AlbumAddViewModel()
        {
            ArtistsIds = new List<int>();
            TrackIds = new List<int>();
        }
        [Key]
        public int AlbumId { get; set; }
        public string Coordinator { get; set; }
        public string Genre { get; set; }

        public string Name { get; set; }
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public string UrlAlbum { get; set; }
        public int ArtistId { get; set; }
        public IEnumerable<int> ArtistsIds { get; set; }
        public IEnumerable<int> TrackIds { get; set; }
    }
}