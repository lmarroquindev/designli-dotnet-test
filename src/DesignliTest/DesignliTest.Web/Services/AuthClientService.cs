using DesignliTest.Core.Dto.Input.UserApp;
using DesignliTest.Core.Dto.Output.Auth;
using DesignliTest.Core.Dto.Output.Helpers.HttpRequestHelper;
using DesignliTest.Core.Interface.Helpers;
using DesignliTest.Web.Endpoints;
using DesignliTest.Web.Interface;

namespace DesignliTest.Web.Services
{
    /// <summary>
    /// Service used by Razor Pages to authenticate and communicate with the backend API.
    /// This service uses IRequestHelper to perform HTTP requests in a clean and reusable way.
    /// </summary>
    public class AuthClientService : IAuthClientService
    {
        private readonly IHttpRequestHelper _requestHelper;
        private readonly AuthEndpoints _authEndpoints;

        public AuthClientService(IHttpRequestHelper requestHelper,IConfiguration config)
        {
            _requestHelper = requestHelper;
            _authEndpoints = new AuthEndpoints(config["ApiBaseUrl"]!);
        }

       /// <inheritdoc/>
        public async Task<string?> LoginAsync(UserLoginRequest model)
        {
            RequestResultEntidad<TokenResponseDto> result = await _requestHelper.PostAsync<TokenResponseDto>(_authEndpoints.Login(), model);

            if (!result.IsSuccessStatusCode)
                return null;

            return result.Entidad.Token;
        }

    }
}
