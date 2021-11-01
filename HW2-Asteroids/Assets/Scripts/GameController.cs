using UnityEngine;

namespace Asteroids
{
    public class GameController:MonoBehaviour
    {
        private InputController _inputController;
        private PlayerReferece _playerReference;
        private CameraReference _cameraReference;
        private Camera _camera;
        private Player _player;

        private void Start()
        {
            _playerReference = new PlayerReferece();
            _cameraReference = new CameraReference();
            _player = _playerReference.Player;
            _camera = _cameraReference.Camera;
            _inputController = new InputController(_player,_camera);
        }

        private void Update()
        {
            _inputController.Acceleration();
            _inputController.RemoveAcceleration();
            _inputController.Rotation();
        }

        private void FixedUpdate()
        {
            _inputController.Move();
        }
    }
}