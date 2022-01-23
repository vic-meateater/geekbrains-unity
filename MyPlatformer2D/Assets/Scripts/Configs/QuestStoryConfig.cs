using UnityEngine;

namespace MyPlatformer2D
{
    [CreateAssetMenu(fileName = "QuestStoryConfig", menuName = "Configs / Quest Story Config", order = 1)]
    public class QuestStoryConfig : ScriptableObject
    {
        public QuestConfig[] quests;
        public QuestStoryType Type;
    }

    public enum QuestStoryType
    {
        Common,
        Resettable
    }
}