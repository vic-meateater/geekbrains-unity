using UnityEngine;

namespace Asteroids
{
    public class Bullet:MonoBehaviour
    {
        [SerializeField] private float _force;

        internal float Force
        {
            get => _force;
            private set => _force = value;
        }
    }
}