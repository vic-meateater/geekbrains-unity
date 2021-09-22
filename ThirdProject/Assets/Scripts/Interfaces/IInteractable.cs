namespace BananaMan
{
    public interface IInteractable: IAction, IInitialization
    {
        bool IsInteractable { get; }
    }
}