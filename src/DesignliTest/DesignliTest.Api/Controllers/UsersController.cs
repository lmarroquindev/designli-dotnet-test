using DesignliTest.Core.Dto.Output.UserApp;
using DesignliTest.Core.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesignliTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Gets the list of all users in the system.
        /// </summary>
        /// <returns>List of users without password information.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<UserOutputDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllUsers()
        {
            List<UserOutputDto> users = await _userService.GetAllAsync();
            return Ok(users);
        }
    }
}
