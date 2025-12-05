namespace DesignliTest.Web.Middlewares
{
    /// <summary>
    /// Validates the JWT cookie for incoming requests.
    /// Redirects to /Login if no valid token is present.
    /// </summary>
    public class JwtAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value?.ToLower();

            if (path == "/login" ||
                path == "/logout" ||
                path.StartsWith("/css") ||
                path.StartsWith("/js") ||
                path.StartsWith("/lib"))
            {
                await _next(context);
                return;
            }

            var token = context.Request.Cookies["jwt"];
            if (string.IsNullOrEmpty(token))
            {
                context.Response.Redirect("/Login");
                return;
            }

            await _next(context);
        }
    }
}
