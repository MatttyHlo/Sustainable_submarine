using WorldOfZuul.Domain;

namespace UnitTests
{
    public class Tests1
    {
        [SetUp]
        public void Setup1()
        {
            BonusStatistics.TotalPoints = 0;
        }

        [Test]
        public void Statistics_AddPoints_IncrementsTotalByOTwo()
        {
            // Arrange
            var stats = new BonusStatistics();

            // Act
            stats.AddPoints();

            // Assert
            Assert.That(BonusStatistics.TotalPoints, Is.EqualTo(2));
        }

    }
}



 
