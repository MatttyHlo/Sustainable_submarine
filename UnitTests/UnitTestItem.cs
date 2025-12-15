using WorldOfZuul.Domain;

namespace UnitTests
{
    public class UnitTestItem
    {
        [Test]
        public void Item_Constructor_SetsNameCorrectly()
        {
            // Arrange & Act
            var item = new Item("chest");

            // Assert
            Assert.That(item.name, Is.EqualTo("chest"));
        }

        [Test]
        public void Item_ConstructorWithOneParameter_SetsDefaultMessage()
        {
            // Arrange & Act
            var item = new Item("key");

            // Assert
            Assert.That(item.message, Is.EqualTo("Normal key"));
        }
    }
}
