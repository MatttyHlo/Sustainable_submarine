namespace WorldOfZuul
{
    public class Game
    {
        private Room? currentRoom;
        //private Room? previousRoom;

        public Game()
        {
            CreateRooms();
        }

        private void CreateRooms()
        {

  
            Room? main = new("International law \nYou are now standing in the first chamber, where you will find out about the laws that cheep our watters cleen and healty"," ", null);
            main.IsCompleted = true; //main room has no quiz, only international law info 




            Quiz[] Material1Quizzes = new Quiz[3]
            {
                new Quiz(
                    "What materials are best suited for building a sustainable submarine hull?",
                    new string[]
                    {
                        "Biodegradable plastic",
                        "Recycled steel and aluminum",
                        "Cheap iron (unalloyed)",
                        "Titanium alloy"
                    },
                    2,
                    "Biodegradable plastic – Incorrect. Bioplastics can be strong, but in seawater they will decompose quickly, losing strength and destroying the hull.\n" +
                    "Cheap iron (unalloyed) – Incorrect. Ordinary iron rusts quickly in salt water and can’t be used safely.\n" +
                    "Titanium alloy – Incorrect. Titanium is strong and corrosion-resistant but requires enormous energy to produce, giving it very high CO₂ emissions.\n" +
                    "The correct choice is Recycled steel and aluminum – they are durable, corrosion-resistant and have low production emissions.\n"
                ),

                new Quiz(
                    "What materials effectively maintain the temperature inside a submarine, increasing its energy efficiency?",
                    new string[]
                    {
                        "No insulation (bare metal casing)",
                        "Polyurethane foam insulation",
                        "Recyclable thermoplastics",
                        "Thin layer of cheap insulation"
                    },
                    3,
                    "No insulation – Incorrect. Bare metal hulls transfer heat quickly to water; the submarine would be cold.\n" +
                    "Polyurethane foam – Incorrect. Insulates well, but it’s almost impossible to recycle and becomes waste.\n" +
                    "Thin cheap insulation – Incorrect. Too thin to hold temperature; energy use would increase.\n" +
                    "Correct: Recyclable thermoplastics – reusable modern foams that provide insulation and reduce waste.\n"
                ),

                new Quiz(
                    "What materials should be used in the interior of a submarine to ensure minimal toxicity and environmental friendliness?",
                    new string[]
                    {
                        "PVC panels and ordinary plastics",
                        "Natural and recycled materials (flax, basalt, reclaimed wood)",
                        "Asbestos and lead materials",
                        "Chipboard and plywood with formaldehyde resins"
                    },
                    2,
                    "PVC and ordinary plastics – Incorrect. Can release chlorine and dioxins when heated; high CO₂ in production.\n" +
                    "Asbestos and lead – Incorrect. Both are toxic; asbestos causes lung diseases, lead poisons the body.\n" +
                    "Chipboard/plywood with formaldehyde – Incorrect. Emit formaldehyde vapors that irritate lungs and are carcinogenic.\n" +
                    "Correct: Natural and recycled materials – flax, basalt fibers, and reclaimed wood are safe, strong, and sustainable.\n"
                )
                        };




            Quiz[] Fuel2Quizes = new Quiz[3] { new Quiz("Question1", new string[] { "Answer1", "Answer2", "Answer3", "Answer4" }, 2, "Wrong Answer! Try Answer 2."),
                                                   // second quiz
                                               new Quiz("Question2", new string[] { "Answer1", "Answer2", "Answer3", "Answer4" }, 3, "Wrong Answer! Try Answer 3."),
                                                   // third quiz
                                               new Quiz("Question3", new string[] { "Answer1", "Answer2", "Answer3", "Answer4" }, 1, "Wrong Answer! Try Answer 1.") };



            Quiz[] Chemical3Quizes = new Quiz[3] { new Quiz("Question1", new string[] { "Answer1", "Answer2", "Answer3", "Answer4" }, 2, "Wrong Answer! Try Answer 2."),
                                                   // second quiz
                                               new Quiz("Question2", new string[] { "Answer1", "Answer2", "Answer3", "Answer4" }, 3, "Wrong Answer! Try Answer 3."),
                                                   // third quiz
                                               new Quiz("Question3", new string[] { "Answer1", "Answer2", "Answer3", "Answer4" }, 1, "Wrong Answer! Try Answer 1.") };



            Quiz[] WasteManagemnet4Quizes = new Quiz[3] { new Quiz("Question1", new string[] { "Answer1", "Answer2", "Answer3", "Answer4" }, 2, "Wrong Answer! Try Answer 2."),
                                                   // second quiz
                                               new Quiz("Question2", new string[] { "Answer1", "Answer2", "Answer3", "Answer4" }, 3, "Wrong Answer! Try Answer 3."),
                                                   // third quiz
                                               new Quiz("Question3", new string[] { "Answer1", "Answer2", "Answer3", "Answer4" }, 1, "Wrong Answer! Try Answer 1.") };







            Room? demo1 = new("\nYou entered a room called the materials room.", "\nIn this room, you will learn what materials to use for a sustainable submarine." + "\nIn front of you is the fuel room, and behind you the main room." +
              "\nIf you look closely, you will see several objects placed around the room. You have three options where you can go." +
              "\n large metal chest" +
              "\n someone's diary with notes " +
              "\n a strange device that looks like a part of the material", Material1Quizzes);

            Room? demo2 = new("\nYou have enter the engine chamber \nHere you will learn the difference betwen " +
                "\ntypes of fuel a subbmarine can use in todays world", "Try sarching trough the room in order to get some valuable information, it seems you have 3 options now " +
                "\na chest full of mystery" +
                "\na sticky note left by some behind" +
                "\na sycret item that took the shape of a shadowy figure", Fuel2Quizes);

            Room? demo3 = new("Demo3", "You have entered the Demo2 room. In front of you is no room, and behind you the Demo2 room.", Chemical3Quizes);

            Room? demo4 = new("Demo4", "You have entered the Demo2 room. In front of you is no room, and behind you the Demo3 room.", WasteManagemnet4Quizes);



            Room.Link(main, demo1);
            Room.Link(demo1, demo2); 
            Room.Link(demo2, demo3);
            Room.Link(demo3, demo4);




            demo1.Chest = new Item("a small wooden chest", "You open the chest and find a rusty key inside.");
            demo1.Notes = new Item("some old notes", "The notes are faded but you can make out some instructions about operating the submarine's control panel.");
            demo1.NewItem = new Item("a mysterious gadget", "The gadget looks complex, with various buttons and dials. It might be useful later.");




            demo2.Chest = new Item("a small wooden chest:", "  Diesel engines charge batteries on surface, underwater the submarine runs on batteries. \n" +
                                   "Short refuel range unless the sub possesses air-independent-propulsion which is unlikely in  \n" +
                                   "diesel/electric type of submarines.");
            demo2.Notes = new Item("some old notes:", "Onboard uranium fuel based reactor provides huge underwater endurance and constant power. \n" +
                                    "Operationally low CO₂ but produces radioactive waste that greatly impacts the ecosystem in the long term .\r\n");
            demo2.NewItem = new Item("a ghost that talks", "The gadget looks complex, with various buttons and dials. It might be useful later.");





            demo3.Chest = new Item("a small wooden chest", "You open the chest and find a rusty key inside.");
            demo3.Notes = new Item("some old notes", "The notes are faded but you can make out some instructions about operating the submarine's control panel.");
            demo3.NewItem = new Item("starfish", "The gadget looks complex, with various buttons and dials. It might be useful later.");



          
          
            demo4.Chest = new Item("a small wooden chest", "You open the chest and find a rusty key inside.");
            demo4.Notes = new Item("some old notes", "The notes are faded but you can make out some instructions about operating the submarine's control panel.");
            demo4.NewItem = new Item("starfish", "The gadget looks complex, with various buttons and dials. It might be useful later.");

            currentRoom = main;
        }


        public void Play()
        {
            Parser parser = new();

            PrintWelcome();

            bool continuePlaying = true;
            while (continuePlaying)
            {
                Console.WriteLine();
                Console.Write("> ");

                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter a command.");
                    continue;
                }

                Command? command = parser.GetCommand(input);

                if (command == null)
                {
                    Console.WriteLine("I don't know that command.");
                    continue;
                }

                switch (command.Name)
                {
                    case "look":
                        Console.WriteLine(currentRoom?.LongDescription);
                        break;

                    case "back":
                        if (currentRoom.PreviousRoom == null)
                            Console.WriteLine("You can't go forward from here!");
                        else
                            currentRoom = currentRoom.PreviousRoom;
                            Console.WriteLine(currentRoom?.ShortDescription);

                        break;

                    case "forward":
                        if (currentRoom.NextRoom == null)
                            Console.WriteLine("You can't go back from here!");
                        else
                            if (!currentRoom.IsCompleted)  //if room wasn´t completed yet, quiz starts
                        {
                            foreach (Quiz qustion in currentRoom.Quizzes)
                            {
                                qustion.AskQuestion();
                            }
                            currentRoom.IsCompleted = true;
                        }
                        currentRoom = currentRoom.NextRoom;
                        Console.WriteLine(currentRoom?.ShortDescription);

                        break;

                    case "quit":
                        continuePlaying = false;
                        break;

                    case "help":
                        PrintHelp();
                        break;

                    case "open":
                        currentRoom.Chest.ShowMessage();
                        break;

                    case "read":
                        currentRoom.Notes.ShowMessage();
                        break;

                    case "explore":
                        currentRoom.NewItem.ShowMessage();
                        break;

                    default:
                        Console.WriteLine("I don't know what command.");
                        break;
                }
            }

            Console.WriteLine("Thank you for playing World of Zuul!");
        }



        private static void PrintWelcome()
        {
            Console.WriteLine("You heard sounds... something broke... it woke you up. \nWhat? A submarine? How did you get here? \nYou need to find answers!\n ") ;
            Console.WriteLine("You are lost. You are alone. You wander... \naround the cold vast rooms of the submarine. \nLook for some items... They might help you on your mission.\n");
            PrintHelp();
        }

        private static void PrintHelp()
        {
            Console.WriteLine();
            Console.WriteLine("Type         'forward'         to go to the next room.");
            Console.WriteLine("Type          'look'           for more details.");
            Console.WriteLine("Type 'open', 'read', 'explore' to interact with items.");
            Console.WriteLine("Type          'back'           to go to the previous room.");
            Console.WriteLine("Type          'help'           to print this message again.");
            Console.WriteLine("Type          'quit'           to exit the game.");

        }
    }
}
