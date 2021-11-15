using UnityEngine;

namespace Asteroids
{
    internal class MoveRigidbody: IMove
    {
        private readonly Rigidbody2D _shipRigidbody2D;
        private Vector3 _move;
        public float Speed { get; protected set; }

        public MoveRigidbody(Rigidbody2D shipRigidbody2D, float speed)
        {
            _shipRigidbody2D = shipRigidbody2D;
            Speed = speed;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _shipRigidbody2D.AddForce(_move);
        }
    }
}