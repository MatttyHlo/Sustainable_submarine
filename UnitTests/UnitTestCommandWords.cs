using WorldOfZuul.Presentation;

namespace UnitTests
{
    public class UnitTestCommandWords
    {
        [Test]
        public void CommandWords_IsValidCommand_ReturnsTrueForValidCommand()
        {
            // Arrange
            var commandWords = new CommandWords();

            // Act
            bool result = commandWords.IsValidCommand("forward");

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CommandWords_ValidCommands_ContainsAllExpectedCommands()
        {
            // Arrange
            var commandWords = new CommandWords();

            // Assert
            Assert.That(commandWords.ValidCommands, Contains.Item("open"));
            Assert.That(commandWords.ValidCommands, Contains.Item("quit"));
            Assert.That(commandWords.ValidCommands, Contains.Item("help"));
        }
    }
}
