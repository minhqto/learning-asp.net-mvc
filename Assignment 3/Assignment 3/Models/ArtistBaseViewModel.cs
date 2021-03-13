using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assignment_3.EntityModels;
namespace Assignment_3.Models
{
    public class ArtistBaseViewModel
    {
        [Key]
        public int MediaTypeId { get; set; }

        [StringLength(120)]
        public string Name { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}