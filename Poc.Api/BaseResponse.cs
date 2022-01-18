using System.Net;

namespace Poc.Api
{
    public class BaseResponse<T>
    {
        public BaseResponse(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
        }

        public BaseResponse(T response, HttpStatusCode statusCode)
        {
            this.Response = response;
            this.StatusCode = statusCode;
        }

        public T? Response { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}