using DesignliTest.Web.Middlewares;

namespace DesignliTest.Web.Extensions
{
    /// <summary>
    /// Extension methods to add JWT cookie authentication middleware.
    /// </summary>
    public static class JwtAuthMiddlewareExtensions
    {
        /// <summary>
        /// Adds the JWT authentication middleware into the pipeline.
        /// </summary>
        public static IApplicationBuilder UseJwtAuth(this IApplicationBuilder app)
        {
            return app.UseMiddleware<JwtAuthMiddleware>();
        }
    }
}
