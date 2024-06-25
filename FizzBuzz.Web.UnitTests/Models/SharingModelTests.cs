using FizzBuzz.Web.Models;

namespace FizzBuzz.Web.UnitTests.Models
{
    public class SharingModelTests
    {
        [Fact]
        public void SharingModel_NameProperty_CanBeSetAndGet()
        {
            // Arrange
            var model = new SharingModel();
            var expectedName = "Test Name";

            // Act
            model.Name = expectedName;
            var actualName = model.Name;

            // Assert
            Assert.Equal(expectedName, actualName);
        }

        [Fact]
        public void SharingModel_ShareProperty_CanBeSetAndGet()
        {
            // Arrange
            var model = new SharingModel();
            var expectedShare = "Test Share";

            // Act
            model.Share = expectedShare;
            var actualShare = model.Share;

            // Assert
            Assert.Equal(expectedShare, actualShare);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("SomeName")]
        public void SharingModel_NameProperty_AssignsCorrectly(string? name)
        {
            // Arrange
            var model = new SharingModel
            {
                // Act
                Name = name
            };

            // Assert
            Assert.Equal(name, model.Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("SomeShare")]
        public void SharingModel_ShareProperty_AssignsCorrectly(string? share)
        {
            // Arrange
            var model = new SharingModel
            {
                // Act
                Share = share
            };

            // Assert
            Assert.Equal(share, model.Share);
        }
    }
}
