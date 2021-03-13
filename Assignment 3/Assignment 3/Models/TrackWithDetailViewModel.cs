using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assignment_3.EntityModels;
namespace Assignment_3.Models
{
    public class TrackWithDetailViewModel : TrackBaseViewModel
    {
        [Display(Name="Artist Name")]
        public string AlbumArtistName { get; set; }

        [Display(Name="Album Title")]
        public string AlbumTitle { get; set; }

        [Display(Name="Media Type")]
        public MediaTypeBaseViewModel MediaType { get; set; }

       
       
    }
}