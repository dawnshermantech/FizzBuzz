using FizzBuzz.Web.Models;

namespace FizzBuzz.Web.UnitTests.Models
{
    public class ErrorViewModelTests
    {
        [Fact]
        public void RequestId_CanBeSetAndGet()
        {
            // Arrange
            var model = new ErrorViewModel();
            var expectedRequestId = "12345";

            // Act
            model.RequestId = expectedRequestId;
            var actualRequestId = model.RequestId;

            // Assert
            Assert.Equal(expectedRequestId, actualRequestId);
        }

        [Theory]
        [InlineData("12345", true)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void ShowRequestId_ReturnsExpectedResult(string? requestId, bool expectedShowRequestId)
        {
            // Arrange
            var model = new ErrorViewModel
            {
                RequestId = requestId
            };

            // Act
            var actualShowRequestId = model.ShowRequestId;

            // Assert
            Assert.Equal(expectedShowRequestId, actualShowRequestId);
        }
    }
}
