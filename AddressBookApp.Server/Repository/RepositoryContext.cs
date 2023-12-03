using AddressBookApp.Server.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace AddressBookApp.Server.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}