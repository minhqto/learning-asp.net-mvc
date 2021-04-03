using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment5.EntityModels
{
    public class Artist
    {
        public Artist()
        {
            BirthOrStartDate = new DateTime();
            Album = new HashSet<Album>();
        }
        [Required]
        public int ArtistId { get; set; }
        [StringLength(120)]
        public string BirthName { get; set; }
        public DateTime BirthOrStartDate { get; set; }
        [StringLength(120)]
        public string Executive { get; set; }
        [StringLength(120)]
        public string Genre { get; set; }
        [Required]
        [StringLength(120)]
        public string Name { get; set; }
        public string UrlArtist { get; set; }
        public ICollection<Album> Album { get; set; }
    }
}