using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Assignment5.EntityModels;

namespace Assignment5.Models
{
    public class TrackWithDetailViewModel : TrackBaseViewModel
    {
        public TrackWithDetailViewModel()
        {
            AlbumNames = new List<string>();
        }
        [Display(Name="Albums with this track")]
        public IEnumerable<string> AlbumNames { get; set; }
    }
}