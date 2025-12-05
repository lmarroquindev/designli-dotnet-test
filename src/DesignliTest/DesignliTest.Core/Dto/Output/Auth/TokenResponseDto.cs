namespace DesignliTest.Core.Dto.Output.Auth
{
    /// <summary>
    /// Represents a JWT token response returned to the client after successful authentication.
    /// </summary>
    public class TokenResponseDto
    {
        /// <summary>
        /// Serialized JWT token string.
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Token expiration in UTC.
        /// </summary>
        public DateTime ExpiresAtUtc { get; set; }
    }
}
