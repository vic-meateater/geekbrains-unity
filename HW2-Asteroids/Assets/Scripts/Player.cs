using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
            //[SerializeField] private Rigidbody2D _bullet;
        //[SerializeField] private Transform _barrel;
        //[SerializeField] private float _force;
        internal Ship Ship{get; private set; }

        private void Awake()
        {
            var shipRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            var moveTransform = new AccelerationMove(shipRigidbody2D, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            Ship = new Ship(moveTransform, rotation);

        }
/*
        private void Update()
        {
            _inputController.Rotation();
            _inputController.Acceleration();
            _inputController.RemoveAcceleration();
            if (Input.GetButtonDown("Fire1"))
            {
                var temAmmunition = Instantiate(_bullet, _barrel.position, _barrel.rotation);
                temAmmunition.AddForce(_barrel.up * _force);
            }
        }

        private void FixedUpdate()
        {
            _inputController.Move();
        }
*/
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