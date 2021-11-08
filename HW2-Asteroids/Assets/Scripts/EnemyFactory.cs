namespace Asteroids
{
    public class EnemyFactory : IEnemyFactory
    {
        private EnemyReference _enemyReference;
        
        public Enemy CreateAsteroid(Health hp)
        {
            _enemyReference = new EnemyReference();
            var enemy = _enemyReference.Asteroid;
            enemy.DependencyInjectHealth(hp);
            return enemy;
        }

        public Enemy CreateStarship(Health hp)
        {
            _enemyReference = new EnemyReference();
            var enemy = _enemyReference.EnemyStarship;
            enemy.DependencyInjectHealth(hp);
            return enemy;
        }
    }
}