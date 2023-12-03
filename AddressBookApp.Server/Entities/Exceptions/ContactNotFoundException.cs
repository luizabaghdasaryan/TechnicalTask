namespace AddressBookApp.Server.Entities.Exceptions
{
    public sealed class ContactNotFoundException : NotFoundException
    {
        public ContactNotFoundException(int id)
            : base($"The contact with id: {id} doesn't exist in the database.")
        {
        }
    }
}