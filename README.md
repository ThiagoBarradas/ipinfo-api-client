[![Build status](https://ci.appveyor.com/api/projects/status/57sdg29v556oa3k4/branch/master?svg=true)](https://ci.appveyor.com/project/ThiagoBarradas/ipinfo-api-client/branch/master)
[![codecov](https://codecov.io/gh/ThiagoBarradas/ipinfo-api-client/branch/master/graph/badge.svg)](https://codecov.io/gh/ThiagoBarradas/ipinfo-api-client)
[![NuGet Downloads](https://img.shields.io/nuget/dt/IpInfo.Api.Client.svg)](https://www.nuget.org/packages/IpInfo.Api.Client/)
[![NuGet Version](https://img.shields.io/nuget/v/IpInfo.Api.Client.svg)](https://www.nuget.org/packages/IpInfo.Api.Client/)

# IpInfo API Client

SDK to integrate your application with IpInfo.Api.

You must have a API implementing [IpInfo.Api](https://github.com/ThiagoBarradas/ipinfo-api). 
You can change the API implementation to consume other service, but the API contract must be the same.
So you can use this microservice for all your applications and the need to change the final service, you change in one place.

## Install via NuGet

```
PM> Install-Package IpInfo.Api.Client
```

## Dependencies

* [RestSharp](https://github.com/restsharp/RestSharp)
* [Newtonsoft](https://github.com/JamesNK/Newtonsoft.Json)

## How to use

```csharp

IIpInfoApiClient ipInfoClient = new IpInfoApiClient("http://localhost:505");

BaseResponse<GetIpInfoResponse> response = ipInfoClient.GetIpInfo("186.221.52.144");

if (response.StatusCode == HttpStatusCode.OK)
{
	// response.Data.Country : 'BR'
	// response.Data.City : 'Búzios'
	// response.Data.State : 'Rio de Janeiro'
	// response.Data.Latitude : -22.756633
	// response.Data.Longitude : -41.8913727
}

```

# How can I contribute?
Please, refer to [CONTRIBUTING](CONTRIBUTING.md)

# Found something strange or need a new feature?
Open a new Issue following our issue template [ISSUE-TEMPLATE](ISSUE-TEMPLATE.md)

# Changelog
See in [nuget version history](https://www.nuget.org/packages/IpInfo.Api.Client)

