using System.Net;

namespace DesignliTest.Core.Dto.Output.Helpers.HttpRequestHelper
{
    /// <summary>
    /// Represents the result of a non-generic HTTP request.
    /// Contains the raw JSON response, the HTTP status code and a success flag.
    /// </summary>
    public class RequestResult
    {
        /// <summary>
        /// Raw JSON response returned by the remote API.
        /// </summary>
        public string JsonResponse { get; set; }

        /// <summary>
        /// HTTP status code returned by the remote API.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Indicate whether the HTTP response was successful.
        /// </summary>
        public bool IsSuccessStatusCode { get; set; }
    }
}
