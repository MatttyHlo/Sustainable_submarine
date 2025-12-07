using WorldOfZuul.Domain;

namespace UnitTests
{
    public class Tests2
    {
        [SetUp]
        public void Setup2()
        {
            SuperBonusStatistics.TotalPoints = 0;
        }

        [Test]
        public void Statistics_AddPoints_IncrementsTotalByOTwo()
        {
            // Arrange
            var stats = new SuperBonusStatistics();

            // Act
            stats.AddPoints();

            // Assert
            Assert.That(SuperBonusStatistics.TotalPoints, Is.EqualTo(3));
        }

    }
}



 
