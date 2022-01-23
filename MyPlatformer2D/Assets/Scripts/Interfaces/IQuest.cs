using System;


namespace MyPlatformer2D
{
    public interface IQuest : IDisposable
    {

        event EventHandler<IQuest> Completed;
        bool IsCompleted { get; }
        void Reset();
    }
}
