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

            /*Room? outside = new("Outside", "You are standing outside the main entrance of the university. To the east is a large building, to the south is a computing lab, and to the west is the campus pub.");
            Room? theatre = new("Theatre", "You find yourself inside a large lecture theatre. Rows of seats ascend up to the back, and there's a podium at the front. It's quite dark and quiet.");
            Room? pub = new("Pub", "You've entered the campus pub. It's a cozy place, with a few students chatting over drinks. There's a bar near you and some pool tables at the far end.");
            Room? lab = new("Lab", "You're in a computing lab. Desks with computers line the walls, and there's an office to the east. The hum of machines fills the room.");
            Room? office = new("Office", "You've entered what seems to be an administration office. There's a large desk with a computer on it, and some bookshelves lining one wall.");

            outside.SetExits(null, theatre, lab, pub); // North, East, South, West

            theatre.SetExit("west", outside);

            pub.SetExit("east", outside);

            lab.SetExits(outside, office, null, null);

            office.SetExit("west", lab);

            currentRoom = outside;*/

            Room? main = new("Main", "You are standing in the main room. In front of you is the Demo1 room", null);
            main.IsCompleted = true; //main room has no quiz

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




            Room? materialsRoom = new(
                "Materials Room",
                "You entered the materials room. In the room, you see various items. " +
                "At the end of the room, there are two doors, and above them is a sign that says “Fuel Room.” " +
                "Behind you is a door that leads to the start room.",
                Material1Quizzes
            );



            Room? demo2 = new("Demo2", "You have entered the Demo2 room. In front of you is no room, and behind you the Demo1 room.", Demo1Quizes);


            Room.Link(main, materialsRoom);
            Room.Link(materialsRoom, demo2);
            Room.Link(demo2, demo3);
            Room.Link(demo3, demo4);


            materialsRoom.Chest = new Item("a small wooden chest", "You open the chest and find a basalt–flax composite coupon.");
            materialsRoom.Notes = new Item("notepad between pipes", "Notes about sustainable hull and interior materials are attached to the pipes.");
            materialsRoom.NewItem = new Item("composite_sample", "A lightweight basalt–flax composite coupon. It may be useful later.");




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
                Console.WriteLine(currentRoom?.ShortDescription);
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
                        break;

                    case "forward":
                        if (currentRoom.NextRoom == null)
                            Console.WriteLine("You can't go back from here!");
                        else
                            if (!currentRoom.IsCompleted)//if room wasn´t completed yet, quiz starts
                        {
                            foreach (Quiz qustion in currentRoom.Quizzes)
                            {
                                qustion.AskQuestion();
                            }
                            currentRoom.IsCompleted = true;
                        }
                        currentRoom = currentRoom.NextRoom;
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

        /*private void Move(string direction)
        {
            if (currentRoom?.Exits.ContainsKey(direction) == true)
            {
                previousRoom = currentRoom;
                currentRoom = currentRoom?.Exits[direction];
            }
            else
            {
                Console.WriteLine($"You can't go {direction}!");
            }
        }*/


        private static void PrintWelcome()
        {
            Console.WriteLine("You heard sounds... something broke... it woke you up.");
            Console.WriteLine("What? A submarine? How did you get here?");
            Console.WriteLine("You need to find answers!");
            Console.WriteLine(" ");
            Console.WriteLine("You are lost. You are alone. You wander...");
            Console.WriteLine("around the cold vast rooms of the submarine.");
            Console.WriteLine("Look for some items... They might help you on your mission.");
            Console.WriteLine(" ");
            Console.WriteLine("There are also some rooms...");
            Console.WriteLine("Go check them out!");
            PrintHelp();
            Console.WriteLine();
        }

        private static void PrintHelp()
        {
            Console.WriteLine();
            Console.WriteLine("Type 'open', 'read', 'explore' to interact with items.");
            Console.WriteLine("Type 'forward' to go to the next room.");
            Console.WriteLine("Type 'look' for more details.");
            Console.WriteLine("Type 'back' to go to the previous room.");
            Console.WriteLine("Type 'help' to print this message again.");
            Console.WriteLine("Type 'quit' to exit the game.");
        }
    }
}
