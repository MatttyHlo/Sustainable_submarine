namespace WorldOfZuul
{
    public static class TextAssets
    {
        public static void PrintHelp()
        {
            Console.WriteLine(
                "Type   'forward'    to go to the next room."+
                "\nType    'back'      to return to the previous room."+
                "\nType    'look'      to look around for more details."+
                "\nType    'open'      to open the chest in the room."+
                "\nType    'read'      to read the notes you found." +
                "\nType   'explore'    to explore other interesting items." +
                "\nType   'status'     to find out how many points you have." +
                "\nType    'help'      to display this help message again." +
                "\nType    'quit'      to exit the game.");
        }

        public static void PrintWelcome()
        {
            Console.WriteLine("You heard sounds... something broke... it woke you up. \nWhat? A submarine? How did you get here? \nYou need to find answers!\n ");
            Console.WriteLine("You are lost. You are alone. You wander... \naround the cold vast rooms of the submarine. \nLook for some items... They might help you on your mission.\n");
            PrintHelp();
        }
    }
}
