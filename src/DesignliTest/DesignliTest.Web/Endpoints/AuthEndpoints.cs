namespace DesignliTest.Web.Endpoints
{
    /// <summary>
    /// Contains strongly typed API endpoint URLs for authentication.
    /// </summary>
    public class AuthEndpoints
    {
        private readonly string _baseUrl;
        public AuthEndpoints(string baseUrl)
        {
            _baseUrl = $"{baseUrl}/api";
        }

        /// <summary>
        /// Gets the full URL for the login endpoint.
        /// </summary>
        public string Login()
        {
            return $"{_baseUrl}/auth/login";
        }
    }
}
