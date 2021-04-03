using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment5.EntityModels
{
    public class Genre
    {
        [Required]
        public int GenreId { get; set; }
        [StringLength(120)]
        public string Name { get; set; }

    }
}