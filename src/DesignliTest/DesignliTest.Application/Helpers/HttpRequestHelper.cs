using DesignliTest.Core.Dto.Output.Helpers.HttpRequestHelper;
using DesignliTest.Core.Interface.Helpers;
using System.Net;
using System.Text;
using System.Text.Json;

namespace DesignliTest.Application.Helpers
{
    /// <summary>
    /// Implementation for performing HTTP requests returning raw or typed results.
    /// </summary>
    public class HttpRequestHelper : IHttpRequestHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpRequestHelper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Creates an HttpClient from the factory and optionally sets a Bearer token header.
        /// </summary>
        /// <param name="jwtToken">Optional JWT token to be added as Authorization header.</param>
        /// <returns>Configured <see cref="HttpClient"/> instance.</returns>

        private HttpClient CreateClient(string jwtToken = null)
        {
            var client = _httpClientFactory.CreateClient();

            if (!string.IsNullOrWhiteSpace(jwtToken))
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtToken);
            }

            return client;
        }

        /// <inheritdoc/>>
        public async Task<RequestResult> GetAsync(string url, string jwtToken = null)
        {
            HttpClient httpClient = CreateClient(jwtToken);
            HttpResponseMessage response = await httpClient.GetAsync(url);
            httpClient.Dispose();
            bool readAsString = response.IsSuccessStatusCode;
            return await GetQueryResult(response, readAsString);
        }
        /// <inheritdoc/>>
        public async Task<RequestResultEntidad<T>> GetAsync<T>(string url, string jwtToken = null)
        {
            HttpClient httpClient = CreateClient(jwtToken);
            HttpResponseMessage response = await httpClient.GetAsync(url);
            httpClient.Dispose();
            bool readAsString = response.IsSuccessStatusCode;
            RequestResult requestResult = await GetQueryResult(response, readAsString);
            return GetRequestResultEntidad<T>(requestResult);
        }
        /// <inheritdoc/>>
        public async Task<RequestResult> PostAsync(string url, object body, string jwtToken = null)
        {
            HttpClient httpClient = CreateClient(jwtToken);
            StringContent content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url, content);
            httpClient.Dispose();
            return await GetQueryResult(response, true);
        }

        /// <inheritdoc/>>
        public async Task<RequestResultEntidad<T>> PostAsync<T>(string url, object body, string jwtToken = null)
        {
            HttpClient httpClient = CreateClient(jwtToken);
            StringContent content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url, content);
            httpClient.Dispose();
            bool readAsString = response.IsSuccessStatusCode;
            RequestResult requestResult = await GetQueryResult(response, readAsString);
            return GetRequestResultEntidad<T>(requestResult);
        }

        /// <inheritdoc/>>
        public async Task<RequestResult> PutAsync(string url, object body, string jwtToken = null)
        {
            HttpClient httpClient = CreateClient(jwtToken);
            StringContent content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync(url, content);
            httpClient.Dispose();
            return await GetQueryResult(response);
        }

        /// <inheritdoc/>>
        public async Task<RequestResult> DeleteAsync(string url, string jwtToken = null)
        {
            HttpClient httpClient = CreateClient(jwtToken);
            HttpResponseMessage response = await httpClient.DeleteAsync(url);
            httpClient.Dispose();
            return await GetQueryResult(response);
        }

        private async Task<RequestResult> GetQueryResult(HttpResponseMessage httpResponseMessage, bool readAsString = false)
        {
            if (httpResponseMessage.IsSuccessStatusCode == false &&          
                httpResponseMessage.StatusCode != HttpStatusCode.NotFound && 
                httpResponseMessage.StatusCode != HttpStatusCode.BadRequest) 
                throw new ArgumentException($"Error in the external API that the request was made to, Response Code: {httpResponseMessage.StatusCode.ToString()}");

            string response = null;

            if (readAsString)
                response = await httpResponseMessage.Content.ReadAsStringAsync();

            return new RequestResult()
            {
                JsonResponse = response,
                StatusCode = httpResponseMessage.StatusCode,
                IsSuccessStatusCode = httpResponseMessage.IsSuccessStatusCode
            };
        }

        private RequestResultEntidad<TEntidad> GetRequestResultEntidad<TEntidad>(RequestResult request)
        {
            RequestResultEntidad<TEntidad> response = new RequestResultEntidad<TEntidad>();
            response.IsSuccessStatusCode = request.IsSuccessStatusCode;
            response.JsonResponse = request.JsonResponse;
            response.StatusCode = request.StatusCode;

            try
            {
                if (request.IsSuccessStatusCode && string.IsNullOrEmpty(request.JsonResponse) == false)
                    response.Entidad = JsonSerializer.Deserialize<TEntidad>(request.JsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return response;
        }
    }
}
