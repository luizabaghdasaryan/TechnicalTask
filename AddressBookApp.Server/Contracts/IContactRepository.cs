using AddressBookApp.Server.Entities.Models;

namespace AddressBookApp.Server.Contracts
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> RetrieveAllContactsAsync();
        Task<Contact?> RetrieveContactByIdAsync(int id);
        void CreateContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(Contact contact);
        Task SaveAsync();
    }
}