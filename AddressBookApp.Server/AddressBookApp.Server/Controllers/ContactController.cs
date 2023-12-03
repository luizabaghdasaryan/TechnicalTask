using AddressBookApp.Server.Contracts;
using AddressBookApp.Server.Service.Contracts;
using AddressBookApp.Shared.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookApp.Server.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly ILoggerManager _logger;

        public ContactController(ILoggerManager logger, IContactService contactService)
        {
            _contactService = contactService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var contacts = await _contactService.GetAllContactsAsync();

            return Ok(contacts);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var contacts = await _contactService.GetContactByIdAsync(id);

            return Ok(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] ContactForManipulationDto contact)
        {
            var createdContact = await _contactService.CreateContactAsync(contact);

            return CreatedAtAction(nameof(GetContactById), new { id = createdContact.Id }, createdContact);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] ContactForManipulationDto contact)
        {
            await _contactService.UpdateContactAsync(id, contact);
            
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactService.DeleteContactAsync(id);
            
            return NoContent();
        }
    }
}