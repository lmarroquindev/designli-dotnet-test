namespace DesignliTest.Core.Domain
{
    /// <summary>
    /// Represents an application user stored in the system.
    /// Used for authentication and protected resource access.
    /// </summary>
    public class UserApp
    {
        /// <summary>
        /// Gets or sets the unique username of the user.
        /// This value works as the primary key in the database.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the plain text password of the user.
        /// </summary>
        /// <remarks>For this challenge, plain text is acceptable.</remarks>
        public string Password { get; set; } = string.Empty;
    }
}
