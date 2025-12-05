namespace DesignliTest.Web.Endpoints
{
    /// <summary>
    /// Contains strongly typed API endpoint URLs for Users.
    /// </summary>
    public class UserEndpoints
    {
        private readonly string _baseUrl;
        public UserEndpoints(string baseUrl)
        {
            _baseUrl = $"{baseUrl}/api";
        }

        /// <summary>
        /// Gets all users endpoint endpoint.
        /// </summary>
        public string GetAll()
        {
            return $"{_baseUrl}/users";
        }
    }
}
