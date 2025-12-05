using DesignliTest.Core.Dto.Input.UserApp;

namespace DesignliTest.Web.Interface
{
    /// <summary>
    /// Definition of methods to authenticate users.
    /// </summary>
    public interface IAuthClientService
    {
        /// <summary>
        /// Sends user credentials to the API authentication endpoint.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Returns the JWT token if login is successful; otherwise null.</returns>
        Task<string?> LoginAsync(UserLoginRequest model);

    }
}
