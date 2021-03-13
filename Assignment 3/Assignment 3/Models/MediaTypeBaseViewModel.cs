using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assignment_3.EntityModels;

namespace Assignment_3.Models
{
    public class MediaTypeBaseViewModel
    {
        [Key]
        public int MediaTypeId { get; set; }

        [StringLength(120)]
        [Display(Name="Media Type")]
        public string Name { get; set; }
    }
}