namespace AddressBookApp.Shared.DataTransferObjects
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PhysicalAddress { get; set; }

       /* public ContactDto(string fullName, string email, string phoneNumber, string physicalAddress)
        {
            FullName = fullName; 
            Email = email;
            PhoneNumber = phoneNumber;
            PhysicalAddress = physicalAddress;
        }*/
    }
}