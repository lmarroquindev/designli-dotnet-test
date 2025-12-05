using DesignliTest.Application.Service;
using DesignliTest.Core.Domain;
using DesignliTest.Core.Interface.Repository;
using Microsoft.Extensions.Configuration;
using Moq;

namespace DesignliTest.Test.Services
{
    /// <summary>
    /// Unit tests for <see cref="AuthService"/>.
    /// </summary>
    public class AuthServiceTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly IConfiguration _configuration;
        private readonly AuthService _authService;

        public AuthServiceTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();

            var inMemorySettings = new Dictionary<string, string?>
            {
                {"Jwt:Secret", "ThisIsA32ByteLongSecretKeyForHS256!!"},
                {"Jwt:Issuer", "TestIssuer"},
                {"Jwt:Audience", "TestAudience"},
                {"Jwt:ExpiresMinutes", "60"}
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _authService = new AuthService(_mockUserRepository.Object, _configuration);
        }

        /// <summary>
        /// Tests that authenticating with a valid user returns a valid JWT token.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task AuthenticateAsync_ValidUser_ReturnsToken()
        {
            // Arrange
            var username = "user1";
            var password = "password1";

            _mockUserRepository
                .Setup(r => r.GetByCredentialsAsync(username, password))
                .ReturnsAsync(new UserApp
                {
                    Username = username,
                    Password = password
                });

            // Act
            var result = await _authService.AuthenticateAsync(username, password);

            // Assert
            Assert.NotNull(result);
            Assert.False(string.IsNullOrWhiteSpace(result!.Token));
            Assert.True(result.ExpiresAtUtc > DateTime.UtcNow);
        }


        /// <summary>
        /// Tests that authenticating with an invalid user returns null.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task AuthenticateAsync_InvalidUser_ReturnsNull()
        {
            // Arrange
            string username = "invalidUser";
            string password = "wrongPassword";

            _mockUserRepository
                .Setup(r => r.GetByCredentialsAsync(username, password))
                .ReturnsAsync((UserApp?)null);

            // Act
            var result = await _authService.AuthenticateAsync(username, password);

            // Assert
            Assert.Null(result);
        }
    }
}