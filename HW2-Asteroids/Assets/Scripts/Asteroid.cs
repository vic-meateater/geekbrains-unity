using UnityEngine;

namespace Asteroids
{
    public sealed class Asteroid : Enemy
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _damage;
        private Vector3 _movedirection;

        public override void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }

        public override void Move(float horizontal, float vertical, float deltaTime)
        {
            Speed = deltaTime * _speed;
            _movedirection.Set(horizontal * Speed, vertical * Speed, 0.0f);
            GetComponent<Rigidbody2D>().AddForce(_movedirection * Speed);
        }

        protected override void Interaction()
        {
            Player.Health -= _damage;
            Health.ChangeCurrentHealth(Health.Current - _damage);
        }
    }
}