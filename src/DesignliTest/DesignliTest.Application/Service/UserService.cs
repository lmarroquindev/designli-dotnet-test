using DesignliTest.Core.Domain;
using DesignliTest.Core.Dto.Output.UserApp;
using DesignliTest.Core.Interface.Repository;
using DesignliTest.Core.Interface.Service;
using Mapster;

namespace DesignliTest.Application.Service
{
    /// <summary>
    /// Implementation of methods to manage users
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <inheritdoc />
        public async Task<List<UserOutputDto>> GetAllAsync()
        {
            List<UserApp> users = await _userRepository.GetAllAsync();
            return users.Adapt<List<UserOutputDto>>();
        }
    }
}
