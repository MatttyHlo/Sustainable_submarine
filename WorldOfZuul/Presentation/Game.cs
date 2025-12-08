using System;
using WorldOfZuul.DataAccess;
using WorldOfZuul.Domain;

namespace WorldOfZuul.Presentation
{
    public class Game
    {
        private Room? currentRoom;
        private Statistics Statistics = new Statistics();
        private Statistics BonusStatistics = new BonusStatistics();
        private Statistics SuperBonusStatistics = new SuperBonusStatistics();
        private ScoreFileAccess scoreFileAccess = new ScoreFileAccess();

        public Game()
        {
            CreateRooms();
        }

        private void CreateRooms()
        {
            Room? main = new("International Law \nYou are now standing in the first chamber, where you will find out about the laws that keep our waters clean and healthy.", " ", null!);
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
                    "Titanium alloy – Incorrect. Titanium is strong and corrosion-resistant but requires enormous energy to produce, giving it very high CO2 emissions.\n" +
                    "The correct choice is Recycled steel and aluminum – they are durable, corrosion-resistant and have low production emissions.\n",
                    Statistics),

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
                    "Correct: Recyclable thermoplastics – reusable modern foams that provide insulation and reduce waste.\n",
                    BonusStatistics),

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
                    "PVC and ordinary plastics – Incorrect. Can release chlorine and dioxins when heated; high CO2 in production.\n" +
                    "Asbestos and lead – Incorrect. Both are toxic; asbestos causes lung diseases, lead poisons the body.\n" +
                    "Chipboard/plywood with formaldehyde – Incorrect. Emit formaldehyde vapors that irritate lungs and are carcinogenic.\n" +
                    "Correct: Natural and recycled materials – flax, basalt fibers, and reclaimed wood are safe, strong, and sustainable.\n",
                    SuperBonusStatistics)
            };

            Quiz[] Fuel2Quizzes = new Quiz[3]
            {
                new Quiz(
                    "Why is diesel-electric common but environmentally worse?",
                    new string[]
                    {
                        "Runs for a longer period underwater.",
                        "Must surface to charge, once it does it emits exhaust.",
                        "Produces only water as emissions.",
                        "It is dependent on constant recharges."
                    },
                    2,
                    "A: Incorrect. Diesel-electric submarines have limited underwater endurance.\n" +
                    "C: Incorrect. Diesel engines emit exhaust gases, not just water.\n" +
                    "D: Incorrect. While true, this is not the main environmental concern.\n" +
                    "Correct: B — Surfacing produces exhaust and risk of detection.\n",
                    Statistics),

                new Quiz(
                    "What's the main tradeoff for nuclear fuel based submarines?",
                    new string[]
                    {
                        "High endurance but cheap fuel and easy to maintain.",
                        "High endurance with long-term usage, in return, waste and accident risk on maintenance.",
                        "Only used in small research subs.",
                        "Nuclear submarines are silent and have no environmental impact."
                    },
                    2,
                    "A: Incorrect. Nuclear fuel is expensive and maintenance is complex.\n" +
                    "C: Incorrect. Nuclear submarines are typically large military vessels.\n" +
                    "D: Incorrect. Nuclear submarines produce radioactive waste.\n" +
                    "Correct: B — Excellent endurance, but high lifecycle/environmental cost and safety demands.\n",
                    BonusStatistics),

                new Quiz(
                    "Why are hydrogen fuel cells called the 'greenest' submarine power source?",
                    new string[]
                    {
                        "They run on diesel and emit CO2.",
                        "They use uranium to generate steam.",
                        "They produce only water during operation.",
                        "They are cheaper than all other fuel types."
                    },
                    3,
                    "A: Incorrect. Hydrogen fuel cells do not use diesel.\n" +
                    "B: Incorrect. That describes nuclear power, not hydrogen fuel cells.\n" +
                    "D: Incorrect. Hydrogen fuel cells require expensive storage systems.\n" +
                    "Correct: C — Best choice to minimize operational environmental harm, producing only water and heat as emissions.\n",
                    SuperBonusStatistics)
            };

            Quiz[] Chemical3Quizzes = new Quiz[3]
            {
                new Quiz(
                    "You need to choose a coating for your submarine before diving deeper. Which one do you use?",
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
                    "4 : Incorrect. Looks nice, but does not contain any necessary chemical.\n",
                    BonusStatistics),
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
                    "4 : Incorrect. Decorative, but not functional.\n",
                    BonusStatistics),
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
                    "4 : Incorrect. Sugar makes slime grow faster.\n",
                    BonusStatistics)
            };

            Quiz[] WasteManagement4Quizzes = new Quiz[4]
            {
                new Quiz("Question1", new string[] { "Answer1", "Answer2", "Answer3", "Answer4" }, 2, "Wrong Answer! Try Answer 2.", BonusStatistics),
                new Quiz("Question2", new string[] { "Answer1", "Answer2", "Answer3", "Answer4" }, 3, "Wrong Answer! Try Answer 3.", BonusStatistics),
                new Quiz("Question3", new string[] { "Answer1", "Answer2", "Answer3", "Answer4" }, 1, "Wrong Answer! Try Answer 1.", BonusStatistics)
            };

            Room? demo1 = new("\nYou entered a room called the Materials Room.", "\nIn this room, you will learn what materials to use for a sustainable submarine." + "\nIn front of you is the Fuel Room, and behind you the Main Room." +
              "\nIf you look closely, you will see several objects placed around the room. You have three options where you can go." +
              "\n A large metal chest." +
              "\n Someone's diary with notes." +
              "\n A strange device that looks like a part of the material.", Material1Quizzes);

            Room? demo2 = new("\nYou have entered the Engine Chamber." +
                "\nHere you will learn the difference between " +
                "\ntypes of fuel a submarine can use in today's world.", "Try searching through the room in order to get some valuable information. It seems you have 3 options now:" +
                "\n A chest full of mystery." +
                "\n A sticky note left by someone behind." +
                "\n A secret item that took the shape of a shadowy figure.", Fuel2Quizzes);

            Room? demo3 = new("\nYou walk into a room that looks like a laboratory. This is the Chemical Solution Room.\nIn this room, you will learn about different types of chemical solutions used in submarine coating.",
            "\nThere are some objects placed in this room." +
            "\nYou can explore these to find information. The objects are:" +
            "\n A chest." +
            "\n A note glued to the window." +
            "\n A small jar with old toxic coating test.", Chemical3Quizzes);

			Room? demo4 = new("\nYou entered a room called the waste room.",
	    "\nIn this room, you will learn about how to properly sort and manage waste to protect the environment." +
	    "\nIn front of you is the last room, and behind you the chemical room." +
	    "\nIf you look closely, you will see several objects placed around the room. You have three options where you can go." +
	    "\na pile of mixed trash with labels" +
	    "\na recycling bin with different compartments " +
	    "\na digital monitor showing waste statistics", WasteManagement4Quizzes);

			Room.Link(main, demo1);
            Room.Link(demo1, demo2);
            Room.Link(demo2, demo3);
            Room.Link(demo3, demo4);

            demo1.Chest = new Item("a small wooden chest", "You open the chest and find a rusty key inside.");
            demo1.Notes = new Item("some old notes", "The notes are faded but you can make out some instructions about operating the submarine's control panel.");
            demo1.NewItem = new Item("a mysterious gadget", "The gadget looks complex, with various buttons and dials. It might be useful later.");

            demo2.Chest = new Item("a small wooden chest", "Diesel engines charge batteries on the surface; underwater the submarine runs on batteries.\n" +
                                   "Short refuel range unless the sub possesses air-independent propulsion, which is unlikely in\n" +
                                   "diesel/electric type of submarines.");
            demo2.Notes = new Item("some old notes", "Onboard uranium fuel based reactor provides huge underwater endurance and constant power.\n" +
                                    "Operationally low CO2 but produces radioactive waste that greatly impacts the ecosystem in the long term.\n");
            demo2.NewItem = new Item("a glowing container", "Hydrogen fuel cells combine stored hydrogen with oxygen to create electricity, producing only water and heat as emissions.");

            demo3.Chest = new Item("a small wooden chest", "There is a diary inside. You flipped the pages and found something written about how chemical coatings protect the submarine surface from rust and things like salt, germs and barnacles that stick to it.\n");
            demo3.Notes = new Item("some old notes", "Traditional coatings contain toxic metals like TBT and Copper. \n" +
                                   "Non-Toxic coatings like Silicon, Fluoropolymers, Nanostructures are hydrophobic and environment friendly.\n");
            demo3.NewItem = new Item("starfish", "Inside the jar floats a tiny piece of metal—rusted and covered in green slime.");

            demo4.Chest = new Item("a small wooden chest", "You find a tablet that tells you waste levels are critical " +
                "and something needs to be done as soon as possible or the submarine will be filled with poisonous gasses");
			
            
            demo4.Notes = new Item(
				"a piece of paper with some strange words",
				"using your brain,you manage to decode something about composting the trash on the submarine \n" +
				"Understanding this fact may help you overcome future problems within the submarine");

            demo4.NewItem = new Item("a pile of mixed trash with labels:",
                "You see a mix of plastic, metal, paper, and organic waste. \n" +
                "Sorting them correctly is crucial for recycling and reducing landfill impact. \n" +
                "Some items can be composted, others recycled, and some are hazardous and need special disposal.");


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

                if (currentRoom == null)
                {
                    Console.WriteLine("Error: No current room!");
                    continue;
                }

                switch (command.Name)
                {
                    case "look":
                        Console.WriteLine(currentRoom.LongDescription);
                        break;

                    case "back":
                        if (currentRoom.PreviousRoom == null)
                            Console.WriteLine("You can't go back from here!");
                        else
                        {
                            currentRoom = currentRoom.PreviousRoom;
                            Console.WriteLine(currentRoom.ShortDescription);
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
                            Console.WriteLine(currentRoom.ShortDescription);
                        }
                        break;

                    case "quit":
                        continuePlaying = false;
                        break;

                    case "help":
                        TextAssets.PrintHelp();
                        break;

                    case "open":
                        currentRoom.Chest?.ShowMessage();
                        break;

                    case "read":
                        currentRoom.Notes?.ShowMessage();
                        break;

                    case "explore":
                        currentRoom.NewItem?.ShowMessage();
                        break;

                    case "status":
                        Statistics.ShowStatus();
                        break;

                    case "save":
                        scoreFileAccess.SaveScore(Statistics.TotalPoints);
                        break;

                    case "load":
                        Console.WriteLine("Points loaded succesfully.");
                        Statistics.TotalPoints = scoreFileAccess.LoadScore();
                        break;

                    default:
                        Console.WriteLine("I don't know that command.");
                        break;
                }
            }

            Console.WriteLine("Thank you for playing Sustainable Submarine!");
        }
    }
}