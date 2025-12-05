using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DesignliTest.Api.Extensions
{
    /// <summary>
    /// Provides extension to configure JWT Bearer authentication.
    /// </summary>
    public static class AuthExtension
    {
        /// <summary>
        /// Adds JWT Bearer authentication using configuration values under "Jwt".
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <param name="config">Application configuration.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var jwtSection = config.GetSection("Jwt");
            var secret = jwtSection.GetValue<string>("Secret")
                         ?? throw new InvalidOperationException("JWT secret not configured");
            var issuer = jwtSection.GetValue<string?>("Issuer");
            var audience = jwtSection.GetValue<string?>("Audience");

            var key = Encoding.UTF8.GetBytes(secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = !string.IsNullOrWhiteSpace(issuer),
                    ValidIssuer = issuer,
                    ValidateAudience = !string.IsNullOrWhiteSpace(audience),
                    ValidAudience = audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromSeconds(30)
                };
            });

            return services;
        }
    }
}
