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
                var gameObject = Resources.Load<Asteroid>("Prefabs/Enemy/Asteroid");
                _asteroid = Object.Instantiate(gameObject);
                return _asteroid;
            }
        }

        internal EnemyStarship EnemyStarship
        {
            get
            {
                if (_enemyStarship != null) return _enemyStarship;
                var gameObject = Resources.Load<EnemyStarship>("Prefabs/Enemy/EnemyStarShip");
                _enemyStarship = Object.Instantiate(gameObject);
                return _enemyStarship;
            }
        }
    }
}