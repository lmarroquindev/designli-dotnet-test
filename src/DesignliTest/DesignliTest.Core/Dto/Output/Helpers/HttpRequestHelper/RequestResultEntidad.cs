namespace DesignliTest.Core.Dto.Output.Helpers.HttpRequestHelper
{
    /// <summary>
    /// Represents the result of an HTTP request that returns a typed entity.
    /// </summary>
    /// <typeparam name="TEntidad">Type of the deserialized entity.</typeparam>
    public class RequestResultEntidad<TEntidad> : RequestResult
    {
        /// <summary>
        /// Deserialized entity returned by the API.
        /// </summary>
        public TEntidad Entidad { get; set; }
    }
}
