using AddressBookApp.Server.Contracts;
using AddressBookApp.Server.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressBookApp.Server.Repository
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Contact>> RetrieveAllContactsAsync()
        {
            return await RetrieveAll()
                .ToListAsync();
        }

        public async Task<Contact?> RetrieveContactByIdAsync(int id)
        {
            return await RetrieveByCondition(c => c.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public void CreateContact(Contact contact) => Create(contact);

        public void UpdateContact(Contact contact) => Update(contact);

        public void DeleteContact(Contact contact) => Delete(contact);

        public async Task SaveAsync() => await RepositoryContext.SaveChangesAsync();
    }
}