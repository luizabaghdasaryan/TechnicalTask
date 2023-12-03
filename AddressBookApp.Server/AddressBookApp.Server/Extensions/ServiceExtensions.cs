using AddressBookApp.Server.Contracts;
using AddressBookApp.Server.Repository;
using AddressBookApp.Server.Service.Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Service;

namespace AddressBookApp.Server.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Address Book App API", Version = "v1" }));

        public static void ConfigureSqlServerContext(this IServiceCollection services, IConfiguration config) =>
            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(config.GetConnectionString("DbConnection")));

        public static void ConfigureLoggerService(this IServiceCollection services) => 
            services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureContactRepository(this IServiceCollection services) =>
            services.AddScoped<IContactRepository, ContactRepository>();

        public static void ConfigureContactService(this IServiceCollection services) =>
            services.AddScoped<IContactService, ContactService>();

        public static void ConfigureCors(this IServiceCollection services) => 
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.WithOrigins("https://localhost:7103")
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
    }
}