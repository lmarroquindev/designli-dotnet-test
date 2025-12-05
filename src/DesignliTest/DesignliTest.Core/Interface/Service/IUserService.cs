using DesignliTest.Core.Domain;
using DesignliTest.Core.Dto.Output.UserApp;

namespace DesignliTest.Core.Interface.Service
{
    /// <summary>
    /// Defines methods for managing users.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Get all users stored in the system.
        /// </summary>
        /// <returns>A collection of <see cref="UserOutputDto"/>.</returns>
        Task<List<UserOutputDto>> GetAllAsync();
    }
}
