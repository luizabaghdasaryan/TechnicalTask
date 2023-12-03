using AddressBookApp.Server.Contracts;
using AddressBookApp.Server.Entities.Exceptions;
using AddressBookApp.Server.Entities.Models;
using AddressBookApp.Server.Service.Contracts;
using AddressBookApp.Shared.DataTransferObjects;
using AutoMapper;

namespace Service
{
    public sealed class ContactService : IContactService
    {
        private readonly IContactRepository _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactDto>> GetAllContactsAsync()
        {
            var contacts = await _repository.RetrieveAllContactsAsync();

            _logger.LogInfo($"Returned all contacts from database.");

            var contactsDto = _mapper.Map<IEnumerable<ContactDto>>(contacts);

            return contactsDto;
        }

        public async Task<ContactDto?> GetContactByIdAsync(int id)
        {
            var contact = await _repository.RetrieveContactByIdAsync(id);

            if (contact is null)
            {
                _logger.LogError($"Contact with id: {id} hasn't been found in database.");
                throw new ContactNotFoundException(id);
            }

            _logger.LogInfo($"Returned contact with id: {id}");
            var userDto = _mapper.Map<ContactDto>(contact);

            return userDto;
        }

        public async Task<ContactDto> CreateContactAsync(ContactForManipulationDto contact)
        {
            var contactEntity = _mapper.Map<Contact>(contact);
            _repository.CreateContact(contactEntity);
            await _repository.SaveAsync();

            _logger.LogInfo($"New contact created");

            var contactToReturn = _mapper.Map<ContactDto>(contactEntity);

            return contactToReturn;
        }

        public async Task UpdateContactAsync(int id, ContactForManipulationDto contact)
        {
            var contactEntity = await _repository.RetrieveContactByIdAsync(id);

            if (contactEntity is null)
            {
                throw new ContactNotFoundException(id);
            }

            _mapper.Map(contact, contactEntity);

            _repository.UpdateContact(contactEntity);
            await _repository.SaveAsync();

            _logger.LogInfo($"Updated contact with id: {id}");
        }

        public async Task DeleteContactAsync(int id)
        {
            var contact = await _repository.RetrieveContactByIdAsync(id);

            if (contact is null)
            {
                throw new ContactNotFoundException(id);
            }

            _repository.DeleteContact(contact);
            await _repository.SaveAsync();

            _logger.LogInfo("New contact created");
        }
    }
}