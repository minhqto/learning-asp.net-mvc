using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Assignment_3.EntityModels;

namespace Assignment_3.Models
{
    public class TrackAddFormViewModel : TrackAddViewModel
    {
        [Display(Name="Albums")]
        public SelectList AlbumList { get; set; }
        [Display(Name="Media Types")]
        public SelectList MediaTypeList { get; set; }

    }
}