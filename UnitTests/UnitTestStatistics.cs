using WorldOfZuul.Domain;

namespace UnitTests
{
    public class Tests0
    {
        [SetUp]
        public void Setup0()
        {
            Statistics.TotalPoints = 0;
        }

        [Test]
        public void Statistics_AddPoints_IncrementsTotalByOne()
        {
            // Arrange
            var stats = new Statistics();

            // Act
            stats.AddPoints();

            // Assert
            Assert.That(Statistics.TotalPoints, Is.EqualTo(1));
        }

    }
}


