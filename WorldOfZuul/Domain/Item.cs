namespace WorldOfZuul.Domain
{
    public class Item : IInteractable
    {
        public string name { get; }
        public string message { get; }

        public Item(string name)
        {
            this.name = name;
            this.message = $"Normal {name}";
        }

        public Item(string name, string message)
        {
            this.name = name;
            this.message = message;
        }

        public void Interact()
        {
            Console.WriteLine(message);
        }
    }
}
