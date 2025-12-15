using WorldOfZuul.Presentation;

namespace UnitTests
{
    public class UnitTestCommand
    {
        [Test]
        public void Command_Constructor_SetsNameCorrectly()
        {
            // Arrange & Act
            var command = new Command("forward");

            // Assert
            Assert.That(command.Name, Is.EqualTo("forward"));
        }

        [Test]
        public void Command_ConstructorWithOneParameter_SecondWordIsNull()
        {
            // Arrange & Act
            var command = new Command("look");

            // Assert
            Assert.That(command.SecondWord, Is.Null);
        }
    }
}
