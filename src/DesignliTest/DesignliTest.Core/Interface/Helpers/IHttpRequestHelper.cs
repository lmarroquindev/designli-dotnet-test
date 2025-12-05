using DesignliTest.Core.Dto.Output.Helpers.HttpRequestHelper;

namespace DesignliTest.Core.Interface.Helpers
{
    /// <summary>
    /// Defines a contract for performing HTTP requests returning raw or typed results.
    /// </summary>
    public interface IHttpRequestHelper
    {
        /// <summary>
        /// Sends an HTTP GET request to the specified URL and returns a raw <see cref="RequestResult"/>.
        /// </summary>
        /// <param name="url">The request URL (absolute or relative to the configured HttpClient base address).</param>
        /// <param name="jwtToken">Optional JWT token to be sent in the Authorization header as Bearer.</param>
        /// <returns>
        /// A <see cref="RequestResult"/> containing the raw JSON response (if any), HTTP status code and success flag.
        /// </returns>
        Task<RequestResult> GetAsync(string url, string jwtToken = null);

        /// <summary>
        /// Sends an HTTP GET request to the specified URL and attempts to deserialize the JSON response to <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The target type used to deserialize the JSON response into.</typeparam>
        /// <param name="url">The request URL (absolute or relative to the configured HttpClient base address).</param>
        /// <param name="jwtToken">Optional JWT token to be sent in the Authorization header as Bearer.</param>
        /// <returns>
        /// A <see cref="RequestResultEntidad{T}"/> containing the raw JSON, HTTP status code, success flag and the deserialized entity.
        /// When the response is not successful, the <c>Entidad</c> property will be the default value for <typeparamref name="T"/>.
        /// </returns>
        Task<RequestResultEntidad<T>> GetAsync<T>(string url, string jwtToken = null);

        /// <summary>
        /// Sends an HTTP POST request with a JSON body to the specified URL and returns a raw <see cref="RequestResult"/>.
        /// </summary>
        /// <param name="url">The request URL (absolute or relative to the configured HttpClient base address).</param>
        /// <param name="body">The object that will be serialized to JSON and sent as the request body.</param>
        /// <param name="jwtToken">Optional JWT token to be sent in the Authorization header as Bearer.</param>
        /// <returns>
        /// A <see cref="RequestResult"/> containing the raw JSON response (if any), HTTP status code and success flag.
        /// </returns>
        Task<RequestResult> PostAsync(string url, object body, string jwtToken = null);

        /// <summary>
        /// Sends an HTTP POST request with a JSON body to the specified URL and attempts to deserialize the JSON response to <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The target type used to deserialize the JSON response into.</typeparam>
        /// <param name="url">The request URL (absolute or relative to the configured HttpClient base address).</param>
        /// <param name="body">The object that will be serialized to JSON and sent as the request body.</param>
        /// <param name="jwtToken">Optional JWT token to be sent in the Authorization header as Bearer.</param>
        /// <returns>
        /// A <see cref="RequestResultEntidad{T}"/> containing the raw JSON, HTTP status code, success flag and the deserialized entity.
        /// When the response is not successful, the <c>Entidad</c> property will be the default value for <typeparamref name="T"/>.
        /// </returns>
        Task<RequestResultEntidad<T>> PostAsync<T>(string url, object body, string jwtToken = null);

        /// <summary>
        /// Sends an HTTP PUT request with a JSON body to the specified URL and returns a raw <see cref="RequestResult"/>.
        /// </summary>
        /// <param name="url">The request URL (absolute or relative to the configured HttpClient base address).</param>
        /// <param name="body">The object that will be serialized to JSON and sent as the request body.</param>
        /// <param name="jwtToken">Optional JWT token to be sent in the Authorization header as Bearer.</param>
        /// <returns>
        /// A <see cref="RequestResult"/> containing the raw JSON response (if any), HTTP status code and success flag.
        /// </returns>
        Task<RequestResult> PutAsync(string url, object body, string jwtToken = null);

        /// <summary>
        /// Sends an HTTP DELETE request to the specified URL and returns a raw <see cref="RequestResult"/>.
        /// </summary>
        /// <param name="url">The request URL (absolute or relative to the configured HttpClient base address).</param>
        /// <param name="jwtToken">Optional JWT token to be sent in the Authorization header as Bearer.</param>
        /// <returns>
        /// A <see cref="RequestResult"/> containing the raw JSON response (if any), HTTP status code and success flag.
        /// </returns>
        Task<RequestResult> DeleteAsync(string url, string jwtToken = null);
    }
}
