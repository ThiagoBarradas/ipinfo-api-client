using Moq;
using RestSharp;
using System;
using System.Net;
using Xunit;

namespace IpInfo.Api.Client.Test
{
    public class IpInfoApiClientTest
    {
        [Fact]
        public void Should_Return_NotFound()
        {
            // arrange
            IpInfoApiClient client = new IpInfoApiClient("http://localhost:505");

            // mock
            Mock<IRestClient> restClientMock = new Mock<IRestClient>();
            client.RestClient = restClientMock.Object;

            restClientMock.Setup(x => x.Execute(It.IsAny<IRestRequest>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.NotFound
                });

            // act
            var response = client.GetIpInfo("186.221.52.144");

            // assert
            Assert.Null(response.Errors);
            Assert.Null(response.Data);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public void Should_Return_BadRequest()
        {
            // arrange
            IpInfoApiClient client = new IpInfoApiClient("http://localhost:505");

            // mock
            Mock<IRestClient> restClientMock = new Mock<IRestClient>();
            client.RestClient = restClientMock.Object;

            restClientMock.Setup(x => x.Execute(It.IsAny<IRestRequest>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = "{ \"errors\":[{ \"message\":\"'Ip' is a invalid field\", \"property\":\"Ip\" }]}"
                });

            // act
            var response = client.GetIpInfo("186.221.52.144");

            // assert
            Assert.Equal("Ip",response.Errors.Errors[0].Property);
            Assert.Equal("'Ip' is a invalid field", response.Errors.Errors[0].Message);
            Assert.Null(response.Data);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public void Should_Return_OK()
        {
            // arrange
            IpInfoApiClient client = new IpInfoApiClient("http://localhost:505");

            // mock
            Mock<IRestClient> restClientMock = new Mock<IRestClient>();
            client.RestClient = restClientMock.Object;

            restClientMock.Setup(x => x.Execute(It.IsAny<IRestRequest>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = "{\"city\":\"Búzios\",\"state\":\"Rio de Janeiro\",\"country\":\"BR\",\"latitude\":-22.756633,\"longitude\":-41.8913727}"
                }); 

            // act
            var response = client.GetIpInfo("186.221.52.144");

            // assert
            Assert.Null(response.Errors);
            Assert.Equal("BR",response.Data.Country);
            Assert.Equal("Búzios", response.Data.City);
            Assert.Equal("Rio de Janeiro", response.Data.State);
            Assert.Equal(-22.756633, response.Data.Latitude);
            Assert.Equal(-41.8913727, response.Data.Longitude);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void Should_Throws_An_Exception()
        {
            // arrange
            IpInfoApiClient client = new IpInfoApiClient("http://localhost:505");

            // mock
            Mock<IRestClient> restClientMock = new Mock<IRestClient>();
            client.RestClient = restClientMock.Object;

            restClientMock.Setup(x => x.Execute(It.IsAny<IRestRequest>()))
                .Returns(new RestResponse()
                {
                    ErrorException = new TimeoutException("Timeout with API")
                });

            // act 
            Exception ex = Assert.Throws<TimeoutException>(() => 
                client.GetIpInfo("186.221.52.144")
            );

            // assert
            Assert.Equal("Timeout with API", ex.Message);
        }
    }
}
