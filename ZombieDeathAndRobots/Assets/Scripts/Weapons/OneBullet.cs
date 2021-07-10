using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneBullet : MonoBehaviour
{
    //VARIABLES
    [SerializeField] private float _speed;
    [SerializeField] private float _maxLifeTime = 3f;
    private int _damage = 25;

    //REFERENCES
    private Transform parent;
    
    void Start()
    {

        parent = transform.parent;
    }
    public void Init()
    {
        Debug.Log("ShoooT!!");
        Destroy(gameObject, _maxLifeTime);
    }

    private void Update()
    {
        
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            Debug.Log("Shoot enemy");
            other.GetComponent<ITakeDamage>().TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
}
