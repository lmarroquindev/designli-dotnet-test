namespace DesignliTest.Core.Dto.Output.UserApp
{
    /// <summary>
    /// Represents a simplified <see cref="Domain.UserApp"/> returned by the API.
    /// </summary>
    public class UserOutputDto
    {
        /// <summary>
        /// Username of the user.
        /// </summary>
        public string Username { get; set; } = string.Empty;
    }
}
