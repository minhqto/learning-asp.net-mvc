using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment5.EntityModels;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Assignment5.Models
{
    public class TrackAddFormViewModel
    {
        [Key]
        public int TrackId { get; set; }

        public string Clerk { get; set; }
        [Display(Name="Composer names (comma-separated)")]
        public string Composers { get; set; }
        [Display(Name="Track genre")]
        public string Genre { get; set; }
        public SelectList GenreList { get; set; }
        [Display(Name="Track Name")]
        public string Name { get; set; }
        [HiddenInput]
        public string AlbumName { get; set; }
        public int AlbumId { get; set; }
    }
}