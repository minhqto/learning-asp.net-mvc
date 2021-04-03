using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Assignment5.Controllers;
using Assignment5.EntityModels;

namespace Assignment5.Models
{
    public class AlbumWithDetailViewModel
    {
        public AlbumWithDetailViewModel()
        {
            ReleaseDate = new DateTime();
            Artist = new List<ArtistBaseViewModel>();
            Track = new List<TrackBaseViewModel>();
        }
        [Key]
        public int AlbumId { get; set; }
        [Display(Name = "Coordinator who looks after the album")]
        public string Coordinator { get; set; }
        [Display(Name = "Album's Primary Genre")]
        public string Genre { get; set; }
        [Display(Name = "Album Name")]
        public string Name { get; set; }
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Album image (cover art)")]
        public string UrlAlbum { get; set; }
        public IEnumerable<ArtistBaseViewModel> Artist { get; set; }
        public IEnumerable<TrackBaseViewModel> Track { get; set; }
    }
}