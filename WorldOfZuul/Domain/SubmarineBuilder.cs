namespace WorldOfZuul.Domain
{
    public class SubmarineBuilder : ISubmarineBuilder
    {
        private void AskChoice(int correctAnswer, string correctMessage, string wrongMessage)
        {
            Console.Write("Enter your choice: ");
            int choice = GetInput(3);

            if (choice == correctAnswer)
                Console.WriteLine(correctMessage);
            else
                Console.WriteLine(wrongMessage);
        }

        private int GetInput(int range)
        {
            int input;
            try
            {
                input = int.Parse(Console.ReadKey().KeyChar.ToString());
                Console.WriteLine();
                if (input < 1 || input > range)
                    throw new Exception();
            }
            catch
            {
                Console.WriteLine($"Invalid input. Please enter 1-{range}");
                return GetInput(range);
            }
            return input;
        }

        public void BuildSubmarine()
        {
            Console.WriteLine("   SUBMARINE CONSTRUCTION BAY");

            Console.WriteLine("\nIt's time to build your sustainable submarine!");
            Console.WriteLine("Use what you learned to make the right choices.\n");

            // Hull Material
            Console.WriteLine("Choose your Hull Material:");
            Console.WriteLine("1. Biodegradable plastic");
            Console.WriteLine("2. Recycled steel and aluminum");
            Console.WriteLine("3. Cheap iron");
            AskChoice(2, "Excellent! Recycled steel and aluminum are durable and eco-friendly.", "Not the best choice for sustainability.");

            // Fuel Type
            Console.WriteLine("\nChoose your Fuel Type:");
            Console.WriteLine("1. Diesel-electric");
            Console.WriteLine("2. Nuclear power");
            Console.WriteLine("3. Hydrogen fuel cells");
            AskChoice(3, "Great! Hydrogen fuel cells produce only water as emissions.", "Not the greenest option.");

            // Coating
            Console.WriteLine("\nChoose your Coating:");
            Console.WriteLine("1. TBT coating");
            Console.WriteLine("2. Silicon-based coating");
            Console.WriteLine("3. No coating");
            AskChoice(2, "Perfect! Silicon-based coatings are non-toxic.", "That's not environmentally friendly.");

            // Waste Management
            Console.WriteLine("\nChoose your Waste Management:");
            Console.WriteLine("1. Throw waste in ocean");
            Console.WriteLine("2. Proper sorting and recycling");
            Console.WriteLine("3. Burn waste inside");
            AskChoice(2, "Correct! Proper sorting protects the environment.", "That would harm the ocean.");

            Console.WriteLine("   YOUR SUBMARINE IS READY!");
            Console.WriteLine("\nCongratulations! Your sustainable submarine is complete!");
        }

        
    }
}
