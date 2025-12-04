namespace WorldOfZuul.Presentation
{
    public class CommandWords
    {
        public List<string> ValidCommands { get; } = new List<string> { "open", "read", "explore", "forward", "look", "back", "quit", "help", "status", "save", "load" };

        public bool IsValidCommand(string command)
        {
            return ValidCommands.Contains(command);
        }
    }
}
