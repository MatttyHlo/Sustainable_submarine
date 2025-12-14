using WorldOfZuul.Presentation;

namespace UnitTests
{
    public class UnitTestParser
    {
        [Test]
        public void Parser_GetCommand_ReturnsCommandForValidInput()
        {
            // Arrange
            var parser = new Parser();

            // Act
            var command = parser.GetCommand("forward");

            // Assert
            Assert.That(command, Is.Not.Null);
            Assert.That(command.Name, Is.EqualTo("forward"));
        }
    }
}
