namespace DesignliTest.Core.Dto.Input.UserApp
{
    /// <summary>
    /// Contains the credentials required to authenticate a user.
    /// </summary>
    public class UserLoginRequest
    {
        /// <summary>
        /// Username used to authenticate.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Password used to authenticate.
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
