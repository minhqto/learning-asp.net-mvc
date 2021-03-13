using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assignment_3.EntityModels;

namespace Assignment_3.Models
{
    public class AlbumBaseViewModel
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        [StringLength(160)]
        public string Title { get; set; }

    }
}