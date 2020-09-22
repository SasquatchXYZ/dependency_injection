using PureDI.Tests.Fakes;
using Xunit;

namespace PureDI.Tests
{
    public class SalutationTests
    {
        [Fact]
        public void ExclaimWillWriteCorrectMessageToMessageWriter()
        {
            // Arrange
            var writer = new SpyMessageWriter();

            var sut = new Salutation(writer);

            // Act
            sut.Exclaim("Hello DI Tests!");

            // Assert
            Assert.Equal(expected: "Hello DI Tests!", actual: writer.WrittenMessage);
        }
    }
}