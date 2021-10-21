using UnityEngine;

namespace BananaMan
{
    public class PoolZombies : MonoBehaviour
    {
        [SerializeField] private int _poolCount = 1;
        [SerializeField] private Zombie _zombiePrefab;
        [SerializeField] private Player _player;

        private PoolObjects<Zombie> _poolZombies;

        private void Start()
        {
            _poolZombies = new PoolObjects<Zombie>(_zombiePrefab,_poolCount,transform);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                CreateZombie();
            }
        }

        private void CreateZombie()
        {
            var rX = Random.Range(-5f, 5f);
            var rZ = Random.Range(-5f, 5f);
            var y = 0.08f;
            var pt = _player.transform.position;

            var rPositions = new Vector3(pt.x+rX, y, pt.z+rZ);
            var zombie = _poolZombies.GetFreeElement();
            zombie.transform.position = rPositions;
        }
    }
}