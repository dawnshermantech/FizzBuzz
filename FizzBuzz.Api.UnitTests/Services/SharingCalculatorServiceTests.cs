using FizzBuzz.Api.Models;
using FizzBuzz.Api.Extensions;
using FizzBuzz.Api.Services;

namespace FizzBuzz.Api.UnitTests.Services
{
    public class SharingCalculatorServiceTests
    {

        [Theory]
        [InlineData("3", "Star Player", "Welcome Star Player!  Fizz - The value 3 is divisible by 3.")]
        [InlineData("5", "Star Player", "Welcome Star Player!  Buzz - The value 5 is divisible by 5.")]
        [InlineData("15", "Star Player", "Welcome Star Player!  FizzBuzz - The value 15 is divisible by both 3 and 5.")]
        [InlineData("1", "Star Player", "Welcome Star Player!  Ahhhhhh Number 1! The value 1 is a whole number so let's calculate it! - 1 Divided by 3 is 0.33 - 1 Divided by 5 is 0.20")]
        [InlineData("23", "Star Player", "Welcome Star Player!  Ooooooh 23! The value 23 is a whole number so let's calculate it! - 23 Divided by 3 is 7.67 - 23 Divided by 5 is 4.60")]
        [InlineData("2.5", "Star Player", "Welcome Star Player!  The value 2.5 is a decimal number. Getting fancy!")]
        [InlineData("A", "Star Player", "Welcome Star Player!  Invalid Item - A")]
        [InlineData("", "Star Player", "Welcome Star Player!  Invalid Item - empty value")]
        [InlineData("3", null, "Welcome !  Fizz - The value 3 is divisible by 3.")]
        [InlineData("5", null, "Welcome !  Buzz - The value 5 is divisible by 5.")]
        public async Task CalculateShareAsync_ReturnsExpectedResponseForDifferentInputs(string share, string? name, string expectedResponse)
        {
            // Arrange
            var request = new SharingModel { Share = share, Name = name };

            // Act
            var service = new SharingCalculatorService();
            var result = await service.CalculateShareAsync(request);

            // Assert
            Assert.Equal(expectedResponse, result);
        }
    }
}
