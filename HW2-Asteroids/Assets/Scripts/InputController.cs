using UnityEngine;

namespace Asteroids
{
    internal class InputController
    {
        private readonly Ship _ship;
        private Transform _transform;
        private Camera _camera;

        internal InputController(Ship ship, Camera camera)
        {
            _ship = ship;
            _transform = camera.gameObject.transform;
            _camera = camera;
        }

        public void Move()
        {
            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.fixedDeltaTime);
        }

        public void Rotation()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_transform.position);
            _ship.Rotation(direction);
        }

        public void Acceleration()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }
        }

        public void RemoveAcceleration()
        {
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }
        }
    }
}