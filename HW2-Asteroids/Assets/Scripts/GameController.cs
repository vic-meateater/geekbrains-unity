using System;
using UnityEngine;

namespace Asteroids
{
    public class GameController:MonoBehaviour
    {
        private InputController _inputController;
        private Ship _ship;
        private Camera _camera;
        private Player _player;

        private void Start()
        {
            var shipRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(shipRigidbody2D, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Ship(moveTransform, rotation);
            _inputController = new InputController(_ship,_camera);
        }

        private void Update()
        {
            throw new NotImplementedException();
        }

        private void FixedUpdate()
        {
            throw new NotImplementedException();
        }
    }
}