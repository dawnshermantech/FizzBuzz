using System.Net;
using FizzBuzz.Web.Models;
using FizzBuzz.Web.Services;
using Microsoft.Extensions.Configuration;

namespace FizzBuzz.Web.UnitTests.Services
{
    public class SharingCalculatorServiceTests
    {
        private readonly IConfiguration _fakeConfiguration;

        public SharingCalculatorServiceTests()
        {
            var inMemorySettings = new Dictionary<string, string?>
            {
                { "ApiUrl", "https://localhost:5202" }
            };

            _fakeConfiguration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
        }

        [Fact]
        public async Task CalculateShareAsync_ReturnsExpectedResponse_OnSuccess()
        {
            // Arrange
            var request = new SharingModel { Share = "3" };
            var expectedResponse = "Fizz - The value 3 is divisible by 3.";
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(expectedResponse)
            };

            var mockHttpMessageHandler = new MockHttpMessageHandler(mockResponse);
            var httpClient = new HttpClient(mockHttpMessageHandler);

            var service = new SharingCalculatorService(httpClient, _fakeConfiguration);

            // Act
            var result = await service.CalculateShareAsync(request);

            // Assert
            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task CalculateShareAsync_ThrowsHttpRequestException_OnFailure()
        {
            // Arrange
            var request = new SharingModel { Share = "3" };
            var mockResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent("Bad Request")
            };

            var mockHttpMessageHandler = new MockHttpMessageHandler(mockResponse);
            var httpClient = new HttpClient(mockHttpMessageHandler);

            var service = new SharingCalculatorService(httpClient, _fakeConfiguration);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<HttpRequestException>(() => service.CalculateShareAsync(request));
            Assert.Contains("Error occurred while calling the API. Status code: BadRequest, Error: Bad Request", exception.Message);
        }

        [Fact]
        public async Task CalculateShareAsync_ThrowsHttpRequestException_OnException()
        {
            // Arrange
            var request = new SharingModel { Share = "3" };

            var mockHttpMessageHandler = new MockHttpMessageHandler(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("Internal Server Error")
            });
            var httpClient = new HttpClient(mockHttpMessageHandler);

            var service = new SharingCalculatorService(httpClient, _fakeConfiguration);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<HttpRequestException>(() => service.CalculateShareAsync(request));
            Assert.Contains("Error occurred while calling the API", exception.Message);
        }
    }
}
