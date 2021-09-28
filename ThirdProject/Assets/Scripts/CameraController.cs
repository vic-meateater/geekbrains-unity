using UnityEngine;

namespace BananaMan
{
    public sealed class CameraController: IExecute
    {
        private Transform _mainCamera;

        public CameraController(Transform mainCamera)
        {
            _mainCamera = mainCamera;
        }
        public void Execute()
        {
            //_mainCamera.position = new Vector3(60f, 7f, -1f);
        }
    }
}