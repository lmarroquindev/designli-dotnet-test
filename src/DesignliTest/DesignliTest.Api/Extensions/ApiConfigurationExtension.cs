using Microsoft.OpenApi.Models;
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

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter your JWT token below.\n\nExample: Bearer {your token}"
                };

                c.AddSecurityDefinition("Bearer", securityScheme);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                };

                c.AddSecurityRequirement(securityRequirement);
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowWebApp", policy =>
                {
                    policy.WithOrigins(
                            "https://localhost:7116",
                            "http://localhost:7116"
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
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

            app.UseCors("AllowWebApp");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}
