using UnityEngine;
using System.Collections.Generic;

namespace MyPlatformer2D
{
    [CreateAssetMenu(fileName = "QuestItemConfig", menuName = "Configs / Quest Item Config", order = 1)]
    public class QuestItemConfig : ScriptableObject
    {
        public int questId;
        public List<int> questItemCollection;

    }
}