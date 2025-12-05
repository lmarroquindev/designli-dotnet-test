using DesignliTest.Infrastructure.InitialData;
using DesignliTest.Infrastructure;

namespace DesignliTest.Api.Extensions
{
    /// <summary>
    /// Provides helper methods to apply database initialization actions such as seeding
    /// </summary>
    public static class SeedExtension
    {
        /// <summary>
        /// Applies pending migrations (if any) and executes the database seeding logic.
        /// Should be called after the application has been built.
        /// </summary>
        /// <param name="app">The application instance.</param>
        /// <returns>The same application instance for chaining.</returns>
        public static WebApplication ApplySeed(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            SeedData.Initialize(db);
            return app;
        }
    }
}
