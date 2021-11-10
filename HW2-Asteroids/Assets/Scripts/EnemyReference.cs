using UnityEngine;

namespace Asteroids
{
    public sealed class EnemyReference
    {
        private Asteroid _asteroid;
        private EnemyStarship _enemyStarship;
        internal Asteroid Asteroid
        {
            get
            {
                if (_asteroid != null) return _asteroid;
                _asteroid = Resources.Load<Asteroid>("Prefabs/Enemy/Asteroid");
                return _asteroid;
            }
        }

        internal EnemyStarship EnemyStarship
        {
            get
            {
                if (_enemyStarship != null) return _enemyStarship;
                _enemyStarship = Resources.Load<EnemyStarship>("Prefabs/Enemy/EnemyStarship");
                return _enemyStarship;
            }
        }
    }
}