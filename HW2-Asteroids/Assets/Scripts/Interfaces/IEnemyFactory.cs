namespace Asteroids
{
    public interface IEnemyFactory
    {
        Enemy CreateAsteroid(Health hp);
        Enemy CreateStarship(Health hp);
    }
}