using DesignliTest.Core.Dto.Output.Helpers.HttpRequestHelper;
using DesignliTest.Core.Dto.Output.UserApp;
using DesignliTest.Core.Interface.Helpers;
using DesignliTest.Web.Endpoints;
using DesignliTest.Web.Interface;

namespace DesignliTest.Web.Services
{
    /// <summary>
    /// Implementation of methods for users operations performed by the web application to communicate with the backend API.
    /// </summary>
    public class UserClientService : IUserClientService
    {
        private readonly IHttpRequestHelper _httpRequestHelper;
        private readonly UserEndpoints _endpoints;

        public UserClientService(IHttpRequestHelper httpRequestHelper, IConfiguration config)
        {
            _httpRequestHelper = httpRequestHelper;
            _endpoints = new UserEndpoints(config["ApiBaseUrl"]!);
        }

        /// <inheritdoc/>
        public async Task<List<UserOutputDto>?> GetUsersAsync(string token)
        {
            RequestResultEntidad<List<UserOutputDto>> result = await _httpRequestHelper.GetAsync<List<UserOutputDto>>(_endpoints.GetAll(), token);

            if (!result.IsSuccessStatusCode)
                return null;

            return result.Entidad;
        }
    }
}
