using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assignment_3.EntityModels;
namespace Assignment_3.Models
{
    public class TrackAddViewModel : TrackBaseViewModel
    {
        public TrackAddViewModel() {}

        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        public int? AlbumId { get; set; }
        [Required]
        public int MediaTypeId { get; set; }

        [StringLength(220)]
        public string Composer { get; set; }
        [Display(Name="Song length(ms)")]
        public int Milliseconds { get; set; }

        [Column(TypeName = "numeric")]
        public decimal UnitPrice { get; set; }


    }
}