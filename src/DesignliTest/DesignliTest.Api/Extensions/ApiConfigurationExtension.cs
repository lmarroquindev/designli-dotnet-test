using System.Reflection;

namespace DesignliTest.Api.Extensions
{
    /// <summary>
    /// Provides configuration helpers for API-level functionality, including controllers,
    /// Swagger, authentication, and general middleware setup.
    /// </summary>
    public static class ApiConfigurationExtension
    {
        /// <summary>
        /// Registers essential API services such as controllers, Swagger, and API metadata.
        /// </summary>
        /// <param name="services">The service collection used for DI registration.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });

            return services;
        }

        /// <summary>
        /// Configures the API middleware pipeline, including Swagger UI, HTTPS redirection,
        /// authentication, and authorization.
        /// </summary>
        /// <param name="app">The application instance.</param>
        /// <returns>The configured application instance.</returns>
        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app)
        {
            var env = app.ApplicationServices.GetRequiredService<IHostEnvironment>();

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            return app;
        }
    }
}
