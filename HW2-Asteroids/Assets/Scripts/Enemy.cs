using UnityEngine;
using Asteroids.ObjectPool;

namespace Asteroids
{
    public abstract class Enemy : InteractiveObject, IMove
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
        
        public abstract void DependencyInjectHealth(Health hp);
        public float Speed { get; protected set; }
        public abstract void Move(float horizontal, float vertical, float deltaTime);

    }
}