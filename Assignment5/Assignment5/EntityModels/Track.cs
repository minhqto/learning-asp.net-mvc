using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Assignment5.EntityModels
{
    public class Track
    {
        public Track()
        {
            Albums = new HashSet<Album>();
        }
        [Required]
        public int TrackId { get; set; }

        [StringLength(120)]
        public string Clerk { get; set; }
        [StringLength(120)]
        public string Composers { get; set; }
        [StringLength(120)]
        public string Genre { get; set; }
        [Required]
        [StringLength(120)]
        public string Name { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}