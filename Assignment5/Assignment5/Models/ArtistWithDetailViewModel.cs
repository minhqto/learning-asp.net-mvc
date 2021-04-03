using Assignment5.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment5.Models
{
    public class ArtistWithDetailViewModel
    {

        public ArtistWithDetailViewModel()
        {
            Album = new List<AlbumBaseViewModel>();
        }
        [Key]
        public int ArtistId { get; set; }
        [Display(Name = "If applicable, artist's birth name")]
        public string BirthName { get; set; }
        [Display(Name = "Birth date, or start date")]
        public DateTime BirthOrStartDate { get; set; }
        [Display(Name = "Executive who looks after this artist")]
        public string Executive { get; set; }
        [Display(Name = "Artist primary genre")]
        public string Genre { get; set; }
        [Display(Name = "Artist name or stage name")]
        public string Name { get; set; }
        [Display(Name = "Artist Photo")]
        public string UrlArtist { get; set; }
        public IEnumerable<AlbumBaseViewModel> Album { get; set; }


    }
}