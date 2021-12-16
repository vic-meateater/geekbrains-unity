using UnityEngine;

namespace MyPlatformer2D
{
    public class BulletController : MonoBehaviour
    {
        private Vector3 _velocity;

        private LevelObjectView _view;

        public BulletController(LevelObjectView view)
        {
            _view = view;
        }


        public void Throw()
        {

        }
    }
}
