using AddressBookApp.Shared.DataTransferObjects;

namespace AddressBookApp.Client.Services
{
    public interface IContactService
    {
        Task<ContactDto[]?> GetContactsAsync();
        Task<ContactDto?> GetContactByIdAsync(int id);
        Task<int> CreateContactAsync(ContactForManipulationDto contact);
        Task UpdateContactAsync(int id, ContactForManipulationDto contact);
        Task DeleteContactAsync(int id);
    }
}