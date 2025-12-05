using DesignliTest.Core.Dto.Output.UserApp;

namespace DesignliTest.Web.Interface
{
    /// <summary>
    /// Defines the methods for users operations performed by the web application to communicate with the backend API.
    /// </summary>
    public interface IUserClientService
    {

        /// <summary>
        /// Gets all users from the protected API endpoint.
        /// </summary>
        /// <param name="token">The JWT token used for authorization.</param>
        /// <returns>
        /// A list of <see cref="UserOutputDto"/> representing the users in the system,
        /// or <c>null</c> if the request fails.
        /// </returns>
        Task<List<UserOutputDto>?> GetUsersAsync(string token);
    }
}
