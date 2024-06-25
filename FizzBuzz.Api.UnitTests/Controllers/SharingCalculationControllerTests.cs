using FizzBuzz.Api.Controllers;
using FizzBuzz.Api.Models;
using FizzBuzz.Api.Services;
using Microsoft.AspNetCore.Mvc;
using FizzBuzz.Api.Extensions;

namespace FizzBuzz.Api.UnitTests.Controllers
{
    public class SharingCalculationControllerTests
    {
        private readonly SharingCalculationController _controller;
        private readonly ISharingCalculatorService _fakeService;

        public SharingCalculationControllerTests()
        {
            _fakeService = A.Fake<ISharingCalculatorService>();
            _controller = new SharingCalculationController(_fakeService);
        }

        [Theory]
        [InlineData(null, "Welcome Star Player!  Invalid Item - empty value")]
        [InlineData("", "Welcome Star Player!  Invalid Item - empty value")]
        [InlineData("A", "Welcome Star Player!  Invalid Item - A")]
        [InlineData("a", "Welcome Star Player!  Invalid Item - A")]
        [InlineData("notANumber", "Welcome Star Player!  The value 'notANumber' is not a number, but you knew that!")]
        [InlineData("3", "Welcome Star Player!  Fizz - The value 3 is divisible by 3.")]
        [InlineData("5", "Welcome Star Player!  Buzz - The value 5 is divisible by 5.")]
        [InlineData("15", "Welcome Star Player!  FizzBuzz - The value 15 is divisible by both 3 and 5.")]
        [InlineData("1", "Welcome Star Player!  Ahhhhhh Number 1! The value 1 is a whole number so let's calculate it! - 1 Divided by 3 is 0.33 - 1 Divided by 5 is 0.20")]
        [InlineData("23", "Welcome Star Player!  Ooooooh 23! The value 23 is a whole number so let's calculate it! - 23 Divided by 3 is 7.67 - 23 Divided by 5 is 4.60")]
        [InlineData("2.5", "Welcome Star Player!  The value 2.5 is a decimal number. Getting fancy!")]
        public async Task Post_ReturnsExpectedResult(string? share, string expectedResponse)
        {
            // Arrange
            var model = new SharingModel { Share = share, Name = "Star Player" };
            var welcomeMessage = "Welcome";
            var calculatedResponse = model.MapSharingResponse(welcomeMessage).Trim(); 

            A.CallTo(() => _fakeService.CalculateShareAsync(model)).Returns(Task.FromResult(calculatedResponse));

            // Act
            var result = await _controller.Post(model);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedResponse, okResult.Value);
        }

        [Fact]
        public async Task Post_ReturnsBadRequest_ForInvalidModel()
        {
            // Arrange
            var model = new SharingModel { Share = null };
            _controller.ModelState.AddModelError("Share", "Required");

            // Act
            var result = await _controller.Post(model);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }
    }
}
