using DesignliTest.Core.Dto.Input.UserApp;
using DesignliTest.Core.Dto.Output.Auth;
using DesignliTest.Core.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace DesignliTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Authenticates a user with username and password and returns a JWT token.
        /// </summary>
        /// <param name="request">The login request containing username and password.</param>
        /// <returns>A JWT token if authentication is successful.</returns>
        [HttpPost("Login")]
        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TokenResponseDto token = await _authService.AuthenticateAsync(request.Username, request.Password);

            if (token == null)
                return BadRequest("Invalid username or password.");

            return Ok(token);
        }
    }
}
