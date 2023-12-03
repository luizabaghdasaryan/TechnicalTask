using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AddressBookApp.Server.Entities.Models;

namespace Repository.Configuration
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasData
            (
                new Contact
                {
                    Id = 1,
                    FirstName = "Armen",
                    LastName = "Grigoryan",
                    Email = "armen.grigoryan@example.com",
                    PhoneNumber = "+37491012345",
                    PhysicalAddress = "Street 1, Yerevan"
                },
                new Contact
                {
                    Id = 2,
                    FirstName = "Ani",
                    LastName = "Harutyunyan",
                    Email = "ani.harutyunyan@example.com",
                    PhoneNumber = "+37491567890",
                    PhysicalAddress = "Not Specified"
                },
                new Contact
                {
                    Id = 3,
                    FirstName = "Anna",
                    LastName = "Sargsyan",
                    Email = "anna.sargsyan@example.com",
                    PhoneNumber = "+37499321098",
                    PhysicalAddress = "Street 42, Gyumri"
                },
                new Contact
                {
                    Id = 4,
                    FirstName = "Sahak",
                    LastName = "Sahakyan",
                    Email = "sahak.sahakyan@example.com",
                    PhoneNumber = "+37497654321",
                    PhysicalAddress = "Street 34, Vanadzor"
                },
                new Contact
                {
                    Id = 5,
                    FirstName = "Ani",
                    LastName = "Sahakyan",
                    Email = "ani.sahakyan@example.com",
                    PhoneNumber = "+37494123456",
                    PhysicalAddress = "Street 34, Yerevan"
                }
            );
        }
    }
}