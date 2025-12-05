using DesignliTest.Application.Service;
using DesignliTest.Core.Interface.Service;

namespace DesignliTest.Api.Extensions
{
    /// <summary>
    /// Provides extension methods for registering application layer services
    /// such as business logic and use case handlers.
    /// </summary>
    public static class ApplicationExtension
    {
        /// <summary>
        /// Registers all services contained in the Application layer,
        /// including business logic services and use case implementations.
        /// </summary>
        /// <param name="services">The service collection used for DI registration.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
