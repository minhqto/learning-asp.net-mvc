using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Assignment2.EntityModels;

namespace Assignment2.Models
{
    public class TrackBaseViewModel 
    { 
    
        [Key]
        [Display(Name = "Track ID")]
        public int TrackId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Display(Name = "Album Identifier")]

        public int? AlbumId { get; set; }
        [Display(Name = "Media Type Identifier")]
        public int MediaTypeId { get; set; }
        [Display(Name = "Genre Identifier")]
        public int? GenreId { get; set; }

        [StringLength(220)]
        [Display(Name = "Composer Name(s)")]
        public string Composer { get; set; }
        [Display(Name = "Track length in milliseconds")]
        public int Milliseconds { get; set; }
        [Display(Name = "Bytes")]
        public int? Bytes { get; set; }
        [Display(Name = "Price")]
        public decimal UnitPrice { get; set; }

        public Album Album { get; set; }


    }
}