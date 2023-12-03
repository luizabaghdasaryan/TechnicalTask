using System.ComponentModel.DataAnnotations;

namespace AddressBookApp.Shared.DataTransferObjects
{
    public class ContactForManipulationDto
    {
        [Required(ErrorMessage = "First Name is a required field.")]
        [RegularExpression("^[A-Z][a-z]{1,49}$", ErrorMessage = "The first letter of Fist Name must be capital and minimum length is 2.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is a required field.")]
        [RegularExpression("^[A-Z][a-z]{1,49}$", ErrorMessage = "The first letter of Last Name must be capital and minimum length is 2.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is a required field.")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone Number is a required field.")]
        [RegularExpression(@"^\+374[1 - 9]\d{7}$", ErrorMessage = "The phone format is invalid.")]
        public string? PhoneNumber { get; set; }

        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters.")]
        public string? PhysicalAddress { get; set; }
    }
}