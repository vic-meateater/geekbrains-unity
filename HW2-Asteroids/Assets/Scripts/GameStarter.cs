using Asteroids.ObjectPool;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        private void Start()
        {
            // Enemy.CreateAsteroidEnemy(new Health(100f, 100f));
            //
            // IEnemyFactory factory = new EnemyFactory();
            // factory.CreateStarship(new Health(100f, 100f));

            EnemyPool enemyAsteroidPool = new EnemyPool(3);
            EnemyPool enemyStarshipPool = new EnemyPool(2);
            
            var enemyAsteroid = enemyAsteroidPool.GetEnemy("Asteroid");
            enemyAsteroid.transform.position = Vector3.zero;
            enemyAsteroid.gameObject.SetActive(true);
            
            var enemyStarship = enemyStarshipPool.GetEnemy("EnemyStarship");
            enemyStarship.transform.position = Vector3.zero;
            enemyStarship.gameObject.SetActive(true);
            
        }
    }
}