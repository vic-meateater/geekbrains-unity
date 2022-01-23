using System;

namespace MyPlatformer2D
{
    public interface IQuestStory : IDisposable
    {
        bool IsDone { get; }
    }
}