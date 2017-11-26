using IpInfo.Api.Client.Models;

namespace IpInfo.Api.Client
{
    public interface IIpInfoApiClient
    {
        BaseResponse<GetIpInfoResponse> GetIpInfo(string ip);
    }
}
