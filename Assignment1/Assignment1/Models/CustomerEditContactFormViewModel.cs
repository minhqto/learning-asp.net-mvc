using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class CustomerEditContactFormViewModel : CustomerEditContactViewModel
    {

        [Required]
        [StringLength(40)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(80)]
        public string Company { get; set; }

    }
}