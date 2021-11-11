using UnityEngine;

namespace Asteroids
{
    internal sealed class EnemyStarship : Enemy, IRotation, IShoot
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _damage;
        private Ship _ship;

        private void Awake()
        {
            var shipRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            var moveRigidbody = new MoveRigidbody(shipRigidbody2D, _speed);
            var rotation = new RotationShip(transform);
            var shooting = new ShootingShip(_barrel);
            _ship = new Ship(moveRigidbody, rotation, shooting);
        }

        public override void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }

        public override void Move(float horizontal, float vertical, float deltaTime)
        {
            _ship.Move(horizontal, vertical, deltaTime);
        }

        public void Rotation(Vector3 direction)
        {
            _ship.Rotation(direction);
        }

        public void Shoot()
        {
            _ship.Shoot();
        }

        protected override void Interaction()
        {
            Player.Health -= _damage;
            Health.ChangeCurrentHealth(Health.Current - _damage);
        }
    }
}