namespace WorldOfZuul
{
    public static class Statistics
    {
        public static int Points { get; private set; } = 0;
        public static void AddPoints()
        {
            Points++;
        }

        public static void Reset()
        {
            Points = 0;
        }

        public static void ShowStatus()
        {                                                           
            Console.WriteLine($"You now have {Points} point{(Points == 1 ? "" : "s")}.");//ternary opperator 
        }


    }
}
