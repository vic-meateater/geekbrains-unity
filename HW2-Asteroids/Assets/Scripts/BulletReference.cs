using UnityEngine;

namespace Asteroids
{
    public sealed class BulletReference
    {
        private Bullet _bullet;
        internal Bullet Bullet
        {
            get
            {
                if(_bullet != null) return _bullet;
                _bullet = Resources.Load<Bullet>("Prefabs/Bullet");
                return _bullet;
            }
        }
    }
}