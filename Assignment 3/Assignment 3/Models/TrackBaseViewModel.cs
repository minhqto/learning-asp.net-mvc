using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assignment_3.EntityModels;
namespace Assignment_3.Models
{
    public class TrackBaseViewModel
    {
        [Key]
        public int TrackId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name="Track Name")]
        public string Name { get; set; }

        public int? AlbumId { get; set; }
        public int MediaTypeId { get; set; }

        [StringLength(220)]
        public string Composer { get; set; }
        [Display(Name="Song length(ms)")]
        public int Milliseconds { get; set; }

        public int? Bytes { get; set; }

        [Column(TypeName = "numeric")]
        [Display(Name="Unit Price")]
        public decimal UnitPrice { get; set; }

        [NotMapped]
        public string NameFull
        {
            get
            {
                var ms = Math.Round((((double)Milliseconds / 1000) / 60), 1);
                var composer = string.IsNullOrEmpty(Composer) ? "" : ", composer " + Composer;
                var trackLength = (ms > 0) ? ", " + ms.ToString() + " minutes" : "";
                var unitPrice = (UnitPrice > 0) ? ", $ " + UnitPrice.ToString() : "";
                return string.Format("{0}{1}{2}{3}", Name, composer, trackLength, unitPrice);
            }
        }
        [NotMapped]
        public string NameShort
        {
            get
            {
                var unitPrice = (UnitPrice > 0) ? " $ " + UnitPrice.ToString() : "";
                return string.Format("{0} - {1}", Name, unitPrice);
            }
        }
    }
}