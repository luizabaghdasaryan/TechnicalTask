using AddressBookApp.Server.Entities.Models;
using AddressBookApp.Shared.DataTransferObjects;
using AutoMapper;

namespace AddressBookApp.Server.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Contact, ContactDto>()
                .ForMember(c => c.FullName,
                    opt => opt.MapFrom(x => string.Join(' ', x.FirstName, x.LastName)));

            CreateMap<ContactForManipulationDto, Contact>();

            CreateMap<ContactForManipulationDto, Contact>();
        }
    }
}