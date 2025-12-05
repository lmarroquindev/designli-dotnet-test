using DesignliTest.Core.Dto.Output.Auth;
using DesignliTest.Core.Interface.Repository;
using DesignliTest.Core.Interface.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DesignliTest.Application.Service
{
    /// <summary>
    /// Implements authentication and JWT issuance logic.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        /// <inheritdoc />
        public async Task<TokenResponseDto?> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.GetByCredentialsAsync(username, password);
            if (user == null)
                return null;

            var jwtSection = _configuration.GetSection("Jwt");
            var secret = jwtSection.GetValue<string>("Secret")
                         ?? throw new InvalidOperationException("JWT secret not configured");
            var issuer = jwtSection.GetValue<string?>("Issuer");
            var audience = jwtSection.GetValue<string?>("Audience");
            var expiresMinutes = jwtSection.GetValue<int?>("ExpiresMinutes") ?? 60;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username)
            };

            var now = DateTime.UtcNow;
            var expires = now.AddMinutes(expiresMinutes);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expires,
                SigningCredentials = creds,
                Issuer = issuer,
                Audience = audience
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new TokenResponseDto
            {
                Token = tokenString,
                ExpiresAtUtc = expires
            };
        }
    }
}
