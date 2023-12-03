using AddressBookApp.Server.Contracts;
using AddressBookApp.Server.Middlewares;

namespace AddressBookApp.Server.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app,
       ILoggerManager logger)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}