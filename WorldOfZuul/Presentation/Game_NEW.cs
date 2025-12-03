using WorldOfZuul.Domain;
using WorldOfZuul.DataAccess;

namespace WorldOfZuul.Presentation
{
    public class Game
    {
        private Room? currentRoom;
        private Statistics statistics = new Statistics();
        private ScoreDataAccess scoreDataAccess = new ScoreDataAccess();

        public Game()
        {
            CreateRooms();
        }

        private void CreateRooms()
        {
            Room? main = new("International law \nYou are now standing in the first chamber, where you will find out about the laws that cheep our watters cleen and healty"," ", null);
            main.IsCompleted = true;

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
                    "Cheap iron (unalloyed) – Incorrect. Ordinary iron rusts quickly in salt water and can't be used safely.\n" +
                    "Titanium alloy – Incorrect. Titanium is strong and corrosion-resistant but requires enormous energy to produce, giving it very high CO₂ emissions.\n" +
                    "The correct choice is Recycled steel and aluminum – they are durable, corrosion-resistant and have low production emissions.\n"
               ,new Statistics() ),

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
                    "Polyurethane foam – Incorrect. Insulates well, but it's almost impossible to recycle and becomes waste.\n" +
                    "Thin cheap insulation – Incorrect. Too thin to hold temperature; energy use would increase.\n" +
                    "Correct: Recyclable thermoplastics – reusable modern foams that provide insulation and reduce waste.\n"
                ,new BonusStatistics() ),

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
                ,new SuperBonusStatistics())
            };

            Quiz[] Fuel2Quizes = new Quiz[3] { 
                new Quiz("What fuel is most sustainable?", new string[] { "Answer1", "Answer2", "Answer3", "Answer4" }, 2, "Wrong Answer! Try Answer 2.",statistics),
                new Quiz("Question2", new string[] { "Answer1", "Answer2", "Answer3", "Answer4" }, 3, "Wrong Answer! Try Answer 3.", statistics),
                new Quiz("Question3", new string[] { "Answer1", "Answer2", "Answer3", "Answer4" }, 1, "Wrong Answer! Try Answer 1.",statistics ) 
            };

            Quiz[] Chemical3Quizes = new Quiz[3] 
            { 
                new Quiz(
                 "You need to choose a coating for your submarine before diving deeper.Which one do you use?",
                 new string[] 
                   { 
                     "A traditional TBT coating", 
                     "A smooth Silicon based coating",
                     "No coating",
                     "Glitter paint" 
                     }, 
                     2, 
                     "1 : Incorrect. TBT coatings are toxic. \n" +
                     "3 : Incorrect. No coating will cause the damage of hull. \n" +
                     "4 : Incorrect. Looks nice, but does not contain any necessary chemical.\n", statistics),
                new Quiz(
                 "You find a crack on the hull. There is leftover paint with copper in it. It is fast and strong.\nWhat do you do?",
                  new string[]
                   {
                     "Use the paint with copper",
                     "Ignore it, it is just a small crack",
                     "Apply a silicon-based repair",
                     "Stick a sticker over it"
                      },
                      3,
                      "1 : Incorrect. Copper is toxic.\n" +
                      "2 : Incorrect. Ignoring it will cause greater damage on the submarine.\n" +
                      "4 : Incorrect. Decorative, but not functional.\n" , statistics),
                new Quiz(
                    "You notice green slime forming on the hull. What will you do?", 
                    new string[] 
                    { 
                        "Wipe it off & apply flouropolymer coating",
                        "Spray it with leftover copper paint",
                        "Ignore it",
                        "Add suger on it"
                        },
                        1,
                        "2 : Incorrect. Copper paint is toxic & not ideal for immediate removal.\n" +
                        "3 : Incorrect. It can eventually grow and cause corrosion.\n" +
                        "4 : Incorrect. Sugar makes slime grow faster.\n" , statistics) 
            };

            Quiz[] WasteManagemnet4Quizes = new Quiz[3] { 
                new Quiz("Question1", new string[] { "Answer1", "Answer2", "Answer3", "Answer4" }, 2, "Wrong Answer! Try Answer 2." , statistics),
                new Quiz("Question2", new string[] { "Answer1", "Answer2", "Answer3", "Answer4" }, 3, "Wrong Answer! Try Answer 3." , statistics),
                new Quiz("Question3", new string[] { "Answer1", "Answer2", "Answer3", "Answer4" }, 1, "Wrong Answer! Try Answer 1." , statistics) 
            };

            Room? demo1 = new("\nYou entered a room called the materials room.", "\nIn this room, you will learn what materials to use for a sustainable submarine." + "\nIn front of you is the fuel room, and behind you the main room." +
              "\nIf you look closely, you will see several objects placed around the room. You have three options where you can go." +
              "\n large metal chest" +
              "\n someone's diary with notes " +
              "\n a strange device that looks like a part of the material", Material1Quizzes);

            Room? demo2 = new("\nYou have enter the engine chamber " +
                "\nHere you will learn the difference betwen " +
                "\ntypes of fuel a subbmarine can use in todays world", "Try sarching trough the room in order to get some valuable information, it seems you have 3 options now " +
                "\na chest full of mystery" +
                "\na sticky note left by some behind" +
                "\na sycret item that took the shape of a shadowy figure", Fuel2Quizes);

            Room? demo3 = new("\nYou walk into a room that looks like a laboratory. This is Chemical Solution room.\nIn this room, you will learn about different types of chemical solutions used in submarine coating." ,
            "\nThere are some objects placed in this room." + 
            "\nYou can explore these to find information. The objects are -" + 
            "\nA chest." + 
            "\nA note glued to the window." + 
            "\nA small jar with old toxic coating test." , Chemical3Quizes);

            Room? demo4 = new("Demo4", "You have entered the Demo2 room. In front of you is no room, and behind you the Demo3 room.", WasteManagemnet4Quizes);

            Room.Link(main, demo1);
            Room.Link(demo1, demo2); 
            Room.Link(demo2, demo3);
            Room.Link(demo3, demo4);


            demo1.Chest = new Item("a small wooden chest", "You open the chest and find a rusty key inside.");
            demo1.Notes = new Item("some old notes", "The notes are faded but you can make out some instructions about operating the submarine's control panel.");
            demo1.NewItem = new Item("a mysterious gadget", "The gadget looks complex, with various buttons and dials. It might be useful later.");



            demo2.Chest = new Item("a small wooden chest:", "Diesel engines charge batteries on surface, underwater the submarine runs on batteries. \n" +
                                   "Short refuel range unless the sub possesses air-independent-propulsion which is unlikely in  \n" +
                                   "diesel/electric type of submarines.");
            demo2.Notes = new Item("some old notes:", "Onboard uranium fuel based reactor provides huge underwater endurance and constant power. \n" +
                                    "Operationally low CO₂ but produces radioactive waste that greatly impacts the ecosystem in the long term .\r\n");
            demo2.NewItem = new Item("a ghost that talks", "The gadget looks complex, with various buttons and dials. It might be useful later.");



            demo3.Chest = new Item("a small wooden chest", "There is a diary inside.You flipped the pages and found something written about how chemical coatings protect the submarine surface from rust and things like salt, germs and barnacles that stick to it. \n");
            demo3.Notes = new Item("some old notes", "Traditional coatings contain toxic metals like TBT and Copper. \n" + 
                                   "Non-Toxic coatings like Silicon, Fluoropolymers, Nanostructures are hydrophobic and environment friendly.\n" );
            demo3.NewItem = new Item("starfish", "Inside the jar floats a tiny piece of metal—rusted and covered in green slime.");




            demo4.Chest = new Item("a small wooden chest", "You open the chest and find a rusty key inside.");
            demo4.Notes = new Item("some old notes", "The notes are faded but you can make out some instructions about operating the submarine's control panel.");
            demo4.NewItem = new Item("starfish", "The gadget looks complex, with various buttons and dials. It might be useful later.");

            currentRoom = main;
        }

        public void Play()
        {
            Parser parser = new();

            TextAssets.PrintWelcome();

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
                            Console.WriteLine("You can't go back from here!");
                        else
                        {
                            currentRoom = currentRoom.PreviousRoom;
                            Console.WriteLine(currentRoom?.ShortDescription);
                        }
                        break;

                    case "forward":
                        if (currentRoom.NextRoom == null)
                            Console.WriteLine("You can't go forward from here!");
                        else
                        {
                            if (!currentRoom.IsCompleted)
                            {
                                foreach (Quiz qustion in currentRoom.Quizzes)
                                {
                                    qustion.AskQuestion();
                                }
                                currentRoom.IsCompleted = true;
                            }
                            currentRoom = currentRoom.NextRoom;
                            Console.WriteLine(currentRoom?.ShortDescription);
                        }
                        break;

                    case "quit":
                        continuePlaying = false;
                        break;

                    case "help":
                        TextAssets.PrintHelp();
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

                    case "status":
                        statistics.ShowStatus();
                        break;
                    case "save":
                        scoreDataAccess.SaveScore(2);
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("I don't know what command.");
                        break;
                }
            }

            Console.WriteLine("Thank you for playing Sustainable Submarine!");
        }
    }
}
