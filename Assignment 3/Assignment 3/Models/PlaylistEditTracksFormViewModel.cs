using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Assignment_3.EntityModels;
namespace Assignment_3.Models
{
    public class PlaylistEditTracksFormViewModel
    {
        public PlaylistEditTracksFormViewModel()
        {
            CurrentTracks = new List<TrackBaseViewModel>();
        }
        [Key]
        public int PlaylistId { get; set; }

        [StringLength(120)]
        [Display(Name = "Playlist Tracks")]
        public string Name { get; set; }
        
        public IEnumerable<TrackBaseViewModel> CurrentTracks { get; set; }
        public MultiSelectList PlaylistTracks { get; set; }

        
    }
}