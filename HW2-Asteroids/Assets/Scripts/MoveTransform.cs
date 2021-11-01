using UnityEngine;

namespace Asteroids
{
    internal class MoveTransform: IMove
    {
        private readonly Rigidbody2D _shipRigidbody2D;
        private Vector3 _move;
        
        public float Speed { get; protected set; }
        protected MoveTransform(Rigidbody2D shipRigidbody2D, float speed)
        {
            _shipRigidbody2D = shipRigidbody2D;
            Speed = speed;
        }
        
        public void Move(float horizontal, float vertical, float fixedDeltaTime)
        {
            var speed = fixedDeltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _shipRigidbody2D.AddForce(_move);
        }
    }
}
