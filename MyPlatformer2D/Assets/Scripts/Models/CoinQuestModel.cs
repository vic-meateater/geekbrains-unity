using UnityEngine;

namespace MyPlatformer2D
{
    public class CoinQuestModel : IQuestModel
    {
        private const string Tag = "Player";

        public bool TryComplete(GameObject activator)
        {
            return activator.CompareTag(Tag);
        }
    }
}