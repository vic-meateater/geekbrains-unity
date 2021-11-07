using UnityEngine;

namespace Asteroids
{
    public abstract class Enemy : MonoBehaviour
    {
        private static EnemyReference _enemyReference;
        public Health Health { get; private set; }

        public static Asteroid CreateAsteroidEnemy(Health hp)
        {
            _enemyReference = new EnemyReference();
            var enemy = _enemyReference.Asteroid;
            enemy.Health = hp;
            return enemy;
        }
    }
}