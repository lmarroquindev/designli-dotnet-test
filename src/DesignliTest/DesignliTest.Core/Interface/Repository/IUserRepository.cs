using DesignliTest.Core.Domain;

namespace DesignliTest.Core.Interface.Repository
{
    /// <summary>
    /// Defines the contract for <see cref="Domain.UserApp"/> data access operations.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Gets a user that matches the provided username and password.
        /// Returns null when credentials are invalid.
        /// </summary>
        /// <param name="username">User username.</param>
        /// <param name="password">User password (plain text for this exercise).</param>
        /// <returns>The matching <see cref="UserApp"/> or null when not found.</returns>
        Task<UserApp?> GetByCredentialsAsync(string username, string password);

        /// <summary>
        /// Returns all users in the system.
        /// </summary>
        /// <returns>A list of <see cref="UserApp"/>.</returns>
        Task<IReadOnlyList<UserApp>> GetAllAsync();
    }
}
