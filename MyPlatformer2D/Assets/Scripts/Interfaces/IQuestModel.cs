using UnityEngine;

namespace MyPlatformer2D
{
    public interface IQuestModel 
    {
        bool TryComplete(GameObject actor);
    }
}