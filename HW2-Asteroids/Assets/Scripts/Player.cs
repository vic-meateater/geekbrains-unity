using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Transform _barrel;

        public Ship Ship {get; private set; }
        public float Health
        {
            get => _hp;
            set => _hp = value;
        }

        private void Awake()
        {
            var shipRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            var moveTransform = new AccelerationMove(shipRigidbody2D, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            var shooting = new ShootingShip(_barrel);
            Ship = new Ship(moveTransform, rotation, shooting);

        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _hp--;
            }
        }
    }
}