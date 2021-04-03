using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment5.EntityModels
{
    public class Album
    {
        public Album()
        {
            ReleaseDate = new DateTime();
            Artist = new HashSet<Artist>();
            Track = new HashSet<Track>();
        }

        [Required]
        public int AlbumId { get; set; }
        [StringLength(120)]
        public string Coordinator { get; set; }
        [StringLength(120)]
        public string Genre { get; set; }
        [Required]
        [StringLength(120)]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string UrlAlbum { get; set; }
        public ICollection<Artist> Artist { get; set; }
        public ICollection<Track> Track { get; set; }
    }
}