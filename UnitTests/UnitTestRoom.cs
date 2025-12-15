using WorldOfZuul.Domain;

namespace UnitTests
{
    public class UnitTestRoom
    {
        [Test]
        public void Room_Constructor_SetsDescriptionsCorrectly()
        {
            // Arrange & Act
            var room = new Room("Short", "Long description", new Quiz[0]);

            // Assert
            Assert.That(room.ShortDescription, Is.EqualTo("Short"));
            Assert.That(room.LongDescription, Is.EqualTo("Long description"));
        }

        [Test]
        public void Room_IsCompleted_DefaultsToFalse()
        {
            // Arrange & Act
            var room = new Room("Test", "Test room", new Quiz[0]);

            // Assert
            Assert.That(room.IsCompleted, Is.False);
        }

    }
}
