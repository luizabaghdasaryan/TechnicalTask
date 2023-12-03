using AddressBookApp.Shared.DataTransferObjects;

namespace AddressBookApp.Server.Service.Contracts
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDto>> GetAllContactsAsync();
        Task<ContactDto?> GetContactByIdAsync(int id);
        Task<ContactDto> CreateContactAsync(ContactForManipulationDto contact);
        Task UpdateContactAsync(int id, ContactForManipulationDto contact);
        Task DeleteContactAsync(int id);
    }
}