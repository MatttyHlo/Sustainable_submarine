//using WorldOfZuul.Domain;

//namespace WorldOfZuul.Presentation
//{
//    /// <summary>
//    /// Game class handles user interaction and game flow.
//    /// This is part of the Presentation Layer.
//    /// It delegates business logic to the Domain layer (GameManager).
//    /// </summary>
//    public class Game
//    {
//        private GameManager gameManager;

//        public Game()
//        {
//            gameManager = new GameManager();
//        }

//        public void Play()
//        {
//            Parser parser = new();

//            TextAssets.PrintWelcome();

//            bool continuePlaying = true;
//            while (continuePlaying)
//            {
//                Console.WriteLine();
//                Console.Write("> ");

//                string? input = Console.ReadLine();

//                if (string.IsNullOrEmpty(input))
//                {
//                    Console.WriteLine("Please enter a command.");
//                    continue;
//                }

//                Command? command = parser.GetCommand(input);

//                if (command == null)
//                {
//                    Console.WriteLine("I don't know that command.");
//                    continue;
//                }

//                switch (command.Name)
//                {
//                    case "look":
//                        Console.WriteLine(gameManager.GetCurrentRoom()?.LongDescription);
//                        break;

//                    case "back":
//                        if (!gameManager.CanMoveBack())
//                        {
//                            Console.WriteLine("You can't go back from here!");
//                        }
//                        else
//                        {
//                            gameManager.MoveToPreviousRoom();
//                            Console.WriteLine(gameManager.GetCurrentRoom()?.ShortDescription);
//                        }
//                        break;

//                    case "forward":
//                        if (!gameManager.CanMoveForward())
//                        {
//                            Console.WriteLine("You can't go forward from here!");
//                        }
//                        else
//                        {
//                            gameManager.MoveToNextRoom();
//                            Console.WriteLine(gameManager.GetCurrentRoom()?.ShortDescription);
//                        }
//                        break;

//                    case "quit":
//                        continuePlaying = false;
//                        break;

//                    case "help":
//                        TextAssets.PrintHelp();
//                        break;

//                    case "open":
//                        gameManager.ShowChest();
//                        break;

//                    case "read":
//                        gameManager.ShowNotes();
//                        break;

//                    case "explore":
//                        gameManager.ExploreNewItem();
//                        break;

//                    case "status":
//                        gameManager.ShowStatus();
//                        break;

//                    default:
//                        Console.WriteLine("I don't know what command.");
//                        break;
//                }
//            }

//            Console.WriteLine("Thank you for playing Sustainable Submarine!");
//        }
//    }
//}
