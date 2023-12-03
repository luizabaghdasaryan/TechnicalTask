using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using AddressBookApp.Server.Repository;

namespace AddressBookApp.Server.RepositoryContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(configuration.GetConnectionString("DbConnection"),
                    b => b.MigrationsAssembly("AddressBookApp.Server"));

            return new RepositoryContext(builder.Options);
        }
    }
}