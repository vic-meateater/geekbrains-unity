using UnityEngine;

namespace Asteroids
{
    internal sealed class ShootingShip:IShoot
    {
        private BulletReference _bulletReference;
        private Bullet _bullet;
        private readonly Transform _barrel;

        internal ShootingShip(Transform barrel)
        {
            _bulletReference = new BulletReference();
            _bullet = _bulletReference.Bullet;
            _barrel = barrel;
        }
        public void Shoot()
        {
            var temAmmunition = Object.Instantiate(_bullet.GetComponent<Rigidbody2D>(), _barrel.position, _barrel.rotation);
            temAmmunition.AddForce(_barrel.up * _bullet.Force);
        }
    }
}