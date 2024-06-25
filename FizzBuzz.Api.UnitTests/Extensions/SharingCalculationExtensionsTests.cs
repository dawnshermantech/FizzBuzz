using FizzBuzz.Api.Models;
using FizzBuzz.Api.Extensions;

namespace FizzBuzz.Api.UnitTests.Extensions
{
    public class SharingCalculationExtensionsTests
    {
        [Theory]
        [InlineData(null, "Welcome", "Star Player", "Welcome Star Player!  Invalid Item - empty value")]
        [InlineData("", "Welcome", "Star Player", "Welcome Star Player!  Invalid Item - empty value")]
        [InlineData("A", "Welcome", "Star Player", "Welcome Star Player!  Invalid Item - A")]
        [InlineData("3", "Welcome", "Star Player", "Welcome Star Player!  Fizz - The value 3 is divisible by 3.")]
        [InlineData("5", "Welcome", "Star Player", "Welcome Star Player!  Buzz - The value 5 is divisible by 5.")]
        [InlineData("15", "Welcome", "Star Player", "Welcome Star Player!  FizzBuzz - The value 15 is divisible by both 3 and 5.")]
        [InlineData("1", "Welcome", "Star Player", "Welcome Star Player!  Ahhhhhh Number 1! The value 1 is a whole number so let's calculate it! - 1 Divided by 3 is 0.33 - 1 Divided by 5 is 0.20")]
        [InlineData("23", "Welcome", "Star Player", "Welcome Star Player!  Ooooooh 23! The value 23 is a whole number so let's calculate it! - 23 Divided by 3 is 7.67 - 23 Divided by 5 is 4.60")]
        [InlineData("2.5", "Welcome", "Star Player", "Welcome Star Player!  The value 2.5 is a decimal number. Getting fancy!")]
        [InlineData("notANumber", "Welcome", "Star Player", "Welcome Star Player!  The value 'notANumber' is not a number, but you knew that!")]
        [InlineData("15", "Welcome", null, "Welcome !  FizzBuzz - The value 15 is divisible by both 3 and 5.")]
        [InlineData("15", "Welcome", "", "Welcome !  FizzBuzz - The value 15 is divisible by both 3 and 5.")]
        public void MapSharingResponse_ReturnsExpectedResponse(string? share, string welcomeMessage, string? name, string? expectedResponse)
        {
            // Arrange
            var request = new SharingModel { Share = share, Name = name };

            // Act
            var result = request.MapSharingResponse(welcomeMessage);

            // Assert
            Assert.Equal(expectedResponse, result);
        }
    }
}
