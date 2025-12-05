using DesignliTest.Application.Helpers;
using DesignliTest.Core.Interface.Helpers;
using DesignliTest.Web.Interface;
using DesignliTest.Web.Services;

namespace DesignliTest.Web.Extensions
{
    /// <summary>
    /// Extensions to register services and helpers for the Web project.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the necessary services for the web application (Razor Pages, HttpClient, and internal services).
        /// </summary>
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddHttpClient();

            // Helpers
            services.AddScoped<IHttpRequestHelper, HttpRequestHelper>();

            // Internal Services
            services.AddScoped<IAuthClientService, AuthClientService>();
            services.AddScoped<IUserClientService, UserClientService>();

            services.AddHttpContextAccessor();

            return services;
        }
    }
}
