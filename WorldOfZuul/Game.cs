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
                                                   //first quiz
            Quiz[] Matterial1Quizes = new Quiz[3] { new Quiz("Question1", new string[] { "Answer1", "Answer2", "Answer3", "Answer4" }, 2, "Wrong Answer! Try Answer 2."),
                                                   // second quiz
                                               new Quiz("Question2", new string[] { "Answer1", "Answer2", "Answer3", "Answer4" }, 3, "Wrong Answer! Try Answer 3."),
                                                   // third quiz
                                               new Quiz("Question3", new string[] { "Answer1", "Answer2", "Answer3", "Answer4" }, 1, "Wrong Answer! Try Answer 1.") };


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


          




            Room? demo1 = new("Demo1", "You have entered the Demo1 room. In front of you is the Demo2 room, and behind you the main room.", Matterial1Quizes);

            Room? dem02 = new("Demo2", "You have entered the Demo2 room. In front of you is no room, and behind you the Demo1 room.", Fuel2Quizes);

            Room? dem03 = new("Demo2", "You have entered the Demo2 room. In front of you is no room, and behind you the Demo1 room.", Chemical3Quizes);

            Room? dem04 = new("Demo2", "You have entered the Demo2 room. In front of you is no room, and behind you the Demo1 room.", WasteManagemnet4Quizes);






            Room.Link(main, demo1);
            Room.Link(demo1, demo1);

            demo1.Chest = new Item("a small wooden chest", "You open the chest and find a rusty key inside.");
            demo1.Notes = new Item("some old notes", "The notes are faded but you can make out some instructions about operating the submarine's control panel.");
            demo1.NewItem = new Item("a mysterious gadget", "The gadget looks complex, with various buttons and dials. It might be useful later.");

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
            Console.WriteLine("What? How did you get here?");
            Console.WriteLine("You need to find answers!");
            Console.WriteLine(" ");
            Console.WriteLine("You are lost. You are alone.");
            Console.WriteLine("Look for some items... They might help you on your mission.");
            Console.WriteLine(" ");
            Console.WriteLine("There are also some rooms...");
            Console.WriteLine("Go check them out!");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("The goal of this game is to gather information, that will then help you build a sustainable submarine");
            PrintHelp();
            Console.WriteLine();
        }

        private static void PrintHelp()
        {
            Console.WriteLine();
            Console.WriteLine("Type 'look' To see details about the room, like items or newxt rooms name.");
            Console.WriteLine("Type 'open', 'read', 'explore' to interact with items.");
            Console.WriteLine("Type 'forward' to go to the next room.");
            Console.WriteLine("Type 'back' to go to the previous room.");
            Console.WriteLine("Type 'help' to print this message again.");
            Console.WriteLine("Type 'quit' to exit the game.");
        }
    }
}
