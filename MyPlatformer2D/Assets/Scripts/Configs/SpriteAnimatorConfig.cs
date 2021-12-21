using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer2D
{
    public enum AnimState
    {
        Idle = 0,
        Walk = 1,
        Jump = 2,
        Fly = 3
    }
    
    [CreateAssetMenu(fileName = "SpriteAnimationCfg", menuName = "Configs / Animation", order = 1)]
    public class SpriteAnimatorConfig : ScriptableObject
    {
        [Serializable]
        public sealed class SpriteSequence
        {
            public AnimState Track;
            public List<Sprite> Sprites = new();
        }
        public List<SpriteSequence> Sequences = new();
    }
}