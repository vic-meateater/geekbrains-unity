using UnityEngine;

namespace MyPlatformer2D
{
    [CreateAssetMenu(fileName = "QuestConfig", menuName = "Configs / Quest Config", order = 1)]
    public class QuestConfig : ScriptableObject
    {
        public int id;
        public QuestType questType;
    }

    public enum QuestType
    {
        Coins
    }
}
