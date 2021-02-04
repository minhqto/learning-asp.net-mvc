using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class CustomerEditContactViewModel
    {
        [Key]
        public int CustomerId { get; set; }
        [StringLength(24)]
        public string Phone { get; set; }
        [StringLength(24)]
        public string Fax { get; set; }
        [Required]
        [StringLength(60)]
        public string Email { get; set; }
    }
}