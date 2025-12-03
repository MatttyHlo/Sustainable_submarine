namespace WorldOfZuul.Domain
{
    public class Statistics
    {
        // shared total for all instances
        public static int TotalPoints { get; protected set; } = 0;//poate fi mostenit doar odata  == protected set

        public virtual void AddPoints()
        {
            TotalPoints += 1;
        }

        public virtual void ShowStatus()
        {
            Console.WriteLine($"You now have {TotalPoints} point{(TotalPoints == 1 ? "" : "s")}."); // ternary operator
        }
    }

    public class BonusStatistics : Statistics
    {
        public override void AddPoints()
        {
            TotalPoints += 2;
        }
    }

    public class SuperBonusStatistics : Statistics
    {
        public override void AddPoints()
        {
            TotalPoints += 3;
        }
    }
}
