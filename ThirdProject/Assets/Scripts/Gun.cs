using UnityEngine;

namespace BananaMan
{
    public class Gun:MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPref;
        [SerializeField] private Transform _bulletStartPosition;
        public float _firerate = 5f;
        public void Shoot()
        {
            var bulletInstantiate = Instantiate(_bulletPref, _bulletStartPosition.position, transform.rotation);
            bulletInstantiate.GetComponent<RifleBullet>().Init();
        }
    }
}