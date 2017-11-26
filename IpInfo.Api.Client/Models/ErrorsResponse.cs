using System.Collections.Generic;

namespace IpInfo.Api.Client.Models
{
    public class ErrorsResponse
    {
        public List<ErrorItemResponse> Errors { get; set; }

        public ErrorsResponse()
        {
            this.Errors = new List<ErrorItemResponse>();
        }
    }

    public class ErrorItemResponse
    {
        public string Message { get; set; }

        public string Property { get; set; }
    }
}
