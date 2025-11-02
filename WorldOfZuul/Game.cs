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

            Room? main = new("International law", "You are now standing in the first chamber, where you will find out about the laws that cheep our watters cleen and healty", null);
            main.IsCompleted = true; //main room has no quiz, only international law info 




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

            Room? demo2 = new("\nYou have enter the engine chamber ", "Here you will learn the difference betwen \ntypes of fuel a subbmarine can use in todays world", Fuel2Quizes);

            Room? demo3 = new("Demo3", "You have entered the Demo2 room. In front of you is no room, and behind you the Demo2 room.", Chemical3Quizes);

            Room? demo4 = new("Demo4", "You have entered the Demo2 room. In front of you is no room, and behind you the Demo3 room.", WasteManagemnet4Quizes);



            Room.Link(main, demo1);
            Room.Link(demo1, demo2); 
            Room.Link(demo2, demo3);
            Room.Link(demo3, demo4);


            demo1.Chest = new Item("a small wooden chest", "You open the chest and find a rusty key inside.");
            demo1.Notes = new Item("some old notes", "The notes are faded but you can make out some instructions about operating the submarine's control panel.");
            demo1.NewItem = new Item("a mysterious gadget", "The gadget looks complex, with various buttons and dials. It might be useful later.");

            demo2.Chest = new Item("a small wooden chest", "You open the chest and find a rusty key inside.");
            demo2.Notes = new Item("some old notes", "The notes are faded but you can make out some instructions about operating the submarine's control panel.");
            demo2.NewItem = new Item("starfish", "The gadget looks complex, with various buttons and dials. It might be useful later.");


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
                Console.WriteLine(currentRoom?.ShortDescription);
                Console.WriteLine(currentRoom?.LongDescription);
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
                            if (!currentRoom.IsCompleted)  //if room wasn´t completed yet, quiz starts
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
