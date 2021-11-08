using UnityEngine;

namespace Asteroids
{
    public abstract class Enemy : MonoBehaviour
    {
        private static EnemyReference _enemyReference;

        public static IEnemyFactory Factory;
        public Health Health { get; protected set; }

        public static Asteroid CreateAsteroidEnemy(Health hp)
        {
            _enemyReference = new EnemyReference();
            var enemy = _enemyReference.Asteroid;
            enemy.Health = hp;
            return enemy;
        }
        
        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }

    }
}