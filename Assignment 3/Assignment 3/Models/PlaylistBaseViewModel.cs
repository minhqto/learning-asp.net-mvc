using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assignment_3.EntityModels;
namespace Assignment_3.Models
{
    public class PlaylistBaseViewModel
    {
        public PlaylistBaseViewModel()
        {
            Tracks = new List<TrackBaseViewModel>();
        }
        [Key]
        public int PlaylistId { get; set; }

        [StringLength(120)]
        [Display(Name="Playlist name")]
        public string Name { get; set; }

        public int TracksCount { get; set; }
        public IEnumerable<TrackBaseViewModel> Tracks { get; set; }
    }
}
