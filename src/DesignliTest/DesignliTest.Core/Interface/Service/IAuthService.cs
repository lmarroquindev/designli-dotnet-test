using DesignliTest.Core.Dto.Output.Auth;

namespace DesignliTest.Core.Interface.Service
{
    /// <summary>
    /// Defines authentication operations such as validating credentials
    /// and issuing JWT tokens for authenticated users.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Validates the provided username and password and returns a JWT token when the credentials are valid. 
        /// Returns null when credentials are invalid.
        /// </summary>
        /// <param name="username">User's username.</param>
        /// <param name="password">User's password (plain text for this exercise).</param>
        /// <returns>A <see cref="TokenResponseDto"/> containing the JWT and expiration, or null on failure.</returns>
        Task<TokenResponseDto?> AuthenticateAsync(string username, string password);
    }
}
