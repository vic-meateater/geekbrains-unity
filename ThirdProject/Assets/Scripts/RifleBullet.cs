using UnityEngine;

namespace BananaMan
{
    public class RifleBullet : BaseBullet
    {
        public void Init()
        {
            Debug.Log("Init");
            Destroy(gameObject, _maxLifeTime);
        }

    }
}