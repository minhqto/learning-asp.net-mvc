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
        [Required]
        public int AlbumId { get; set; }
        public string Coordinator { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string UrlAlbum { get; set; }
        [Required]
        public int ArtistId { get; set; }
        [Required]
        public IEnumerable<int> ArtistsIds { get; set; }
        [Required]
        public IEnumerable<int> TrackIds { get; set; }
    }
}