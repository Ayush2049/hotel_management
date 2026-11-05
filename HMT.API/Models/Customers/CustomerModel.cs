using System.ComponentModel.DataAnnotations;

namespace HMT.API.Models.Customers
{
    public class CustomerModel
    {
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100.")]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public required string Email { get; set; }

        [Required]
        [StringLength(20)]
        public required string PhoneNumber { get; set; }

        [Required]
        [StringLength(300)]
        public required string Address { get; set; }
    }
}