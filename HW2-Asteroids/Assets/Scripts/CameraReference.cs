using UnityEngine;

namespace Asteroids
{
    public class CameraReference
    {
        private Camera _camera;

        internal Camera Camera
        {
            get
            {
                if (_camera != null) return _camera;
                _camera = Camera.main;
                return _camera;
            }
        }
    }
}