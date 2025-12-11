namespace WorldOfZuul.Domain
{
   public interface IInteractable
   {
        string Name { get; }
        string Message { get; }
        void Interact();
   }
}
