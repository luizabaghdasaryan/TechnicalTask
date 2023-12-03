
using AddressBookApp.Server.Contracts;
using AddressBookApp.Server.Extensions;
using NLog.Config;
using NLog;

namespace AddressBookApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.ConfigureSwagger();

            LogManager.Configuration = new XmlLoggingConfiguration("./nlog.config");
            builder.Services.ConfigureLoggerService();
            builder.Services.ConfigureContactRepository();
            builder.Services.ConfigureContactService();
            builder.Services.ConfigureSqlServerContext(builder.Configuration);
            builder.Services.ConfigureCors();
            builder.Services.AddAutoMapper(typeof(Program));

            var app = builder.Build();

            var logger = app.Services.GetRequiredService<ILoggerManager>();
            app.ConfigureExceptionHandler(logger);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}