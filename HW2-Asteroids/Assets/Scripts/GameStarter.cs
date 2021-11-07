using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        private void Start()
        {
            Enemy.CreateAsteroidEnemy(new Health(100f, 100f));
        }
    }
}