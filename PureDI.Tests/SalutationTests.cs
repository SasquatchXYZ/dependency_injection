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
            sut.Exclaim();

            // Assert
            Assert.Equal(expected: "Hello DI!", actual: writer.WrittenMessage);
        }
    }
}