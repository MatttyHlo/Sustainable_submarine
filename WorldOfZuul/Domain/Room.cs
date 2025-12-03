namespace WorldOfZuul.Domain
{
    public class Room
    {
        public string ShortDescription;
        public string LongDescription;

        public Quiz[] Quizzes = new Quiz[3];
        public bool IsCompleted = false;

        public Room? NextRoom;
        public Room? PreviousRoom;

        public Item Chest = new Item("chest");
        public Item Notes = new Item("notes");
        public Item? NewItem;

        public Dictionary<string, Room> Exits { get; private set; } = new();

        public Room(string shortDesc, string longDesc, Quiz[] quizzes)
        {
            ShortDescription = shortDesc;
            LongDescription = longDesc;
            Quizzes = quizzes;
        }

        public static void Link(Room firstRoom, Room secondRoom)
        {
            firstRoom.NextRoom = secondRoom;
            secondRoom.PreviousRoom = firstRoom;
        }
    }
}
