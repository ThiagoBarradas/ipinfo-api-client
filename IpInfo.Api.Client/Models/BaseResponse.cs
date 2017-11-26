using System.Net;

namespace IpInfo.Api.Client.Models
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }

        public ErrorsResponse Errors { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
