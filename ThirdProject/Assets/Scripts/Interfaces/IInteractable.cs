namespace BananaMan
{
    public interface IInteractable: IInitialization
    {
        bool IsInteractable { get; }
    }
}