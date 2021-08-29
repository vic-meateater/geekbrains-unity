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

        void Update()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
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