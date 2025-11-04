namespace WorldOfZuul
{
    public class Room
    {
        public string ShortDescription;
        public string LongDescription;

        public Quiz[] Quizzes = new Quiz[3];
        public bool IsCompleted = false;

        public Room NextRoom;
        public Room PreviousRoom;

        public Item Chest = new Item("chest");
        public Item Notes = new Item("notes");
        public Item NewItem;

        public Dictionary<string, Room> Exits { get; private set; } = new();

        public Room(string shortDesc, string longDesc, Quiz[] quizzes)
        {
            ShortDescription = shortDesc;
            LongDescription = longDesc;
            Quizzes = quizzes;
        }

        public static void Link(Room firstRoom, Room secondRoom){
            firstRoom.NextRoom = secondRoom;
            secondRoom.PreviousRoom = firstRoom;
        }

        /*public void SetExits(Room? north, Room? east, Room? south, Room? west)
        {
            SetExit("north", north);
            SetExit("east", east);
            SetExit("south", south);
            SetExit("west", west);
        }

        public void SetExit(string direction, Room? neighbor)
        {
            if (neighbor != null)
                Exits[direction] = neighbor;
        }*/

        /*public void ExploreRoom()
        {
            //lists optoins to the user
            Console.WriteLine(ShortDescription);
            Console.WriteLine(LongDescription);
            Console.WriteLine();
            Console.WriteLine($"1. Open Chest");
            Console.WriteLine($"2. Read Notes");
            Console.WriteLine($"3. Expolre {NewItem}");
            Console.WriteLine($"4. Go to {NextRoom.ShortDescription}");
            Console.WriteLine($"5. Go to {PreviousRoom.ShortDescription}");

            Console.Write("Please enter the number of your answer: ");
            int playerAnswer = Quiz.GetInput(5);//gets input from console

            //Handles input
            if (playerAnswer == 1) {
                Chest.ShowMessage();
            }
            else if (playerAnswer == 1)
            {
                Notes.ShowMessage();
            }
            else if (playerAnswer == 3)
            {
                NewItem.ShowMessage();
            }
            else if (playerAnswer == 4)//if room wasn´t completed yet, quiz starts
            {
                if (!IsCompleted)
                {
                    foreach (Quiz qustion in Quizes)
                    {
                        qustion.AskQuestion();
                    }
                    IsCompleted = true;
                }    
                NextRoom.ExploreRoom();
            }
            else if (playerAnswer == 5)
            {
                if (PreviousRoom != null) PreviousRoom.ExploreRoom();

            }
        }*/
    }
}
