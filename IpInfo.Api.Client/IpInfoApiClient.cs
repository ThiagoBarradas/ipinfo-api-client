using IpInfo.Api.Client.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace IpInfo.Api.Client
{
    public class IpInfoApiClient : IIpInfoApiClient
    {
        public string BaseUrl { get; set; }

        public int TimeoutInSeconds { get; set; }

        public IRestClient RestClient { get; set; }

        /// <summary>
        /// Initializes client.
        /// baseUrl must be an URL valid from an API that implements IpInfo.Api project
        /// https://github.com/ThiagoBarradas/ipinfo-api
        /// </summary>
        /// <param name="baseUrl">api host</param>
        /// <param name="timeoutInSeconds">timeout in seconds</param>
        public IpInfoApiClient(string baseUrl, int timeoutInSeconds = 30)
        {
            this.BaseUrl = baseUrl;
            this.TimeoutInSeconds = timeoutInSeconds;
            this.RestClient = new RestClient(this.BaseUrl);
            RestClient.Timeout = this.TimeoutInSeconds * 1000;
        }

        /// <summary>
        /// Get ip info like country, state, city and geolocation
        /// </summary>
        /// <param name="ip">ip as string</param>
        /// <returns></returns>
        public BaseResponse<GetIpInfoResponse> GetIpInfo(string ip)
        {
            BaseResponse<GetIpInfoResponse> response = new BaseResponse<GetIpInfoResponse>();

            IRestRequest restRequest = new RestRequest("ip/{ip}", Method.GET);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddUrlSegment("ip", ip);

            IRestResponse restResponse = RestClient.Execute(restRequest);

            if (restResponse.ErrorException != null)
            {
                throw restResponse.ErrorException;
            }

            response.StatusCode = restResponse.StatusCode;

            if (restResponse.StatusCode == HttpStatusCode.OK && string.IsNullOrWhiteSpace(restResponse.Content) == false)
            {
                response.Data = JsonConvert.DeserializeObject<GetIpInfoResponse>(restResponse.Content);
            }
            else if (string.IsNullOrWhiteSpace(restResponse.Content) == false)
            {
                response.Errors = JsonConvert.DeserializeObject<ErrorsResponse>(restResponse.Content);
            }

            return response;
        }
    }
}
