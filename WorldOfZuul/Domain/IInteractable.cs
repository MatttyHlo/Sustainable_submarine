namespace WorldOfZuul.Domain
{
   public interface IInteractable
   {
        string name { get; }
        string message { get; }
        void Interact();
   }
}
