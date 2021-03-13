using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assignment_3.EntityModels;
namespace Assignment_3.Models
{
    public class PlaylistEditTracksViewModel
    {
        public PlaylistEditTracksViewModel()
        {
            TrackIds = new List<int>();
        }
        [Key]
        public int PlaylistId { get; set; }
        public IEnumerable<int> TrackIds { get; set; }
    }
}