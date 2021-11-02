using UnityEngine;

namespace Asteroids
{
    public class GameController:MonoBehaviour
    {
        private InputController _inputController;
        private PlayerReference _playerReference;
        private CameraReference _cameraReference;
        private Camera _camera;
        private Player _player;

        private void Start()
        {
            _playerReference = new PlayerReference();
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
            _inputController.Fire();
        }

        private void FixedUpdate()
        {
            _inputController.Move();
        }
    }
}