//------------------------------------------------------------------------------
// Injected by scripts/sync_speakeasy_outputs.py DO NOT EDIT.
//------------------------------------------------------------------------------

#nullable enable
namespace Google.GenAI.Gaos.Models.Errors
{
    using System;
    using System.Net.Http;

    /// <summary>
    /// Carrier base bridging gaos 5xx errors onto the native
    /// <see cref="Google.GenAI.ServerError"/> hierarchy while preserving the gaos
    /// Message/Request/Response/Body surface.
    /// </summary>
    public abstract class GaosServerError : Google.GenAI.ServerError
    {
        /// <summary>
        /// Error Message
        /// </summary>
        public override string Message { get; }

        /// <summary>
        /// HTTP Request
        /// </summary>
        public HttpRequestMessage Request { get; }

        /// <summary>
        /// HTTP Response
        /// </summary>
        public HttpResponseMessage Response { get; }

        /// <summary>
        /// HTTP response body
        /// </summary>
        public string Body { get; }

        protected GaosServerError(
            string message,
            HttpRequestMessage request,
            HttpResponseMessage response,
            string body
        ) : this(message, request, response, body, null)
        {
        }

        protected GaosServerError(
            string message,
            HttpRequestMessage request,
            HttpResponseMessage response,
            string body,
            Exception? innerException
        ) : base(message, (int)response.StatusCode, response.ReasonPhrase, innerException!)
        {
            Message = $"{message.TrimEnd('.')}. Body: {body}.";
            Request = request;
            Response = response;
            Body = body;
        }

        /// <summary>
        /// Detailed Error Message
        /// </summary>
        public override string ToString()
        {
            var innerMessage = string.IsNullOrEmpty(InnerException?.Message) ? "" : $"\n{InnerException.Message}";
            return $"Status: {Response.StatusCode}. {Message}{innerMessage}";
        }
    }
}
