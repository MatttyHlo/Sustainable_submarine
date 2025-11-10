//namespace WorldOfZuul
//{
//    public static class Statistics
//    {
//        public static int Points { get; private set; } = 0;  //encapsulation(fundametal methot of OOP)    
//        public static void AddPoints()
//        {
//            Points++;
//        }

//        public static void Reset()
//        {
//            Points = 0;
//        }

//        public static void ShowStatus()
//        {                                                           
//            Console.WriteLine($"You now have {Points} point{(Points == 1 ? "" : "s")}.");//ternary opperator 
//        }


//    }
//}


namespace WorldOfZuul
{
    public class Statistics
    {
        // shared total for all instances
        public static int TotalPoints { get; protected set; } = 0;

        public virtual void AddPoints()
        {
            TotalPoints += 1;
        }

        public virtual void ShowStatus()
        {
            Console.WriteLine($"You now have {TotalPoints} point{(TotalPoints == 1 ? "" : "s")}.");
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
