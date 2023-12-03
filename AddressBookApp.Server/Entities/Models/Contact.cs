using System.ComponentModel.DataAnnotations;

namespace AddressBookApp.Server.Entities.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is a required field.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The first name must be between 2 and 50 characters.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is a required field.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The last name must be between 2 and 50 characters.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is a required field.")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone Number is a required field.")]
        public string? PhoneNumber { get; set; }

        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters")]
        public string? PhysicalAddress { get; set; } = "Not Specified";
    }
}