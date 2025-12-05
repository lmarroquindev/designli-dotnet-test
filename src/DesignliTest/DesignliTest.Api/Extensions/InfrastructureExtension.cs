using DesignliTest.Core.Interface.Repository;
using DesignliTest.Infrastructure;
using DesignliTest.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace DesignliTest.Api.Extensions
{
    /// <summary>
    /// Provides extension methods for configuring infrastructure-level services,
    /// including the DbContext and repository registrations.
    /// </summary>
    public static class InfrastructureExtension
    {
     
        /// <summary>
        /// Registers infrastructure dependencies such as the application's DbContext
        /// and all infrastructure-layer implementations (e.g., repositories).
        /// </summary>
        /// <param name="services">The service collection used for DI registration.</param>
        /// <param name="config">The application configuration object.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration config)
        {
            // EF InMemory (Repositories project)
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("DesignliDb"));

            //Repositories
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
