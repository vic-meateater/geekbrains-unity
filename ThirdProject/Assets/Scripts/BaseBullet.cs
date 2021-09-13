using UnityEngine;

namespace BananaMan
{
    public abstract class BaseBullet : MonoBehaviour
    {
        [SerializeField] protected float _speed;
        [SerializeField] protected float _maxLifeTime;
        [SerializeField] protected int _damage;

        private Transform _parentTransform;
        
        void Start()
        {
            _parentTransform = transform.parent;
        }
        void Update()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
        
        // private void OnTriggerEnter(Collider other)
        // {
        //     if (other.CompareTag("Enemy"))
        //     {
        //         Debug.Log($"Hit {other.name}");
        //         other.GetComponent<ITakeDamage>().TakeDamage(_damage);    
        //     }
        //     Destroy(gameObject, 2f);
        // }
    }
}