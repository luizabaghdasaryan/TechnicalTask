using AddressBookApp.Shared.DataTransferObjects;
using System.Net.Http;
using System.Net.Http.Json;

namespace AddressBookApp.Client.Services
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ContactDto[]?> GetContactsAsync()
        {
            return await _httpClient.GetFromJsonAsync<ContactDto[]>("api/contacts");
        }

        public async Task<ContactDto?> GetContactByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/contacts/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ContactDto?>();
            }

            return null;
        }

        public async Task<int> CreateContactAsync(ContactForManipulationDto contact)
        {
            var response = await _httpClient.PostAsJsonAsync("api/contacts", contact);
            response.EnsureSuccessStatusCode();
            var newContact =  await response.Content.ReadFromJsonAsync<ContactDto>();

            return newContact!.Id;
        }

        public async Task UpdateContactAsync(int id, ContactForManipulationDto contact)
        {
            await _httpClient.PutAsJsonAsync($"api/contacts/{id}", contact);
        }

        public async Task DeleteContactAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/contacts/{id}");
        }
    }
}