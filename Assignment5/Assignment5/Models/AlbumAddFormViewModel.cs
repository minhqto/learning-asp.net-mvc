﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment5.EntityModels;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Assignment5.Models
{
    public class AlbumAddFormViewModel
    {
        public AlbumAddFormViewModel()
        {
            ReleaseDate = new DateTime();
        }
        [Key]
        public int AlbumId { get; set; }
        [Display(Name = "Coordinator who looks after the album")]
        public string Coordinator { get; set; }
      
        [Display(Name = "Album Name")]
        public string Name { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Url to album image (cover art)")]
        public string UrlAlbum { get; set; }
        [Display(Name="Artist Name")]
        public string CurrentArtist { get; set; }
        public int ArtistId { get; set; }
        public MultiSelectList AvailableArtists { get; set; }
        [Display(Name = "Album's Primary Genre")]
        public SelectList Genres { get; set; }
        public MultiSelectList Tracks { get; set; }
    }
}