using System;
using UnityEngine;

namespace BananaMan
{
    public sealed class RifleBullet : BaseBullet
    {
        //public event Action<Vector3, > OnBulletShooting = delegate(string str, Color color) {  }; // доделать стрельбу
        public void Init()
        {
            Debug.Log("Init");
            Destroy(gameObject, _maxLifeTime);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Debug.Log($"Hit {other.name}");
                other.GetComponent<ITakeDamage>().TakeDamage(_damage);    
            }
            Destroy(gameObject, 2f);
        }

    }
}