using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    ///VARIABLES
    [SerializeField] private int _explosionDamage = 100;
    [SerializeField] private float _explosionTime;
    [SerializeField] private float _explosionRadius;

    public void Init()
    {
        Debug.Log("Mine Plant");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            Invoke("Explosion", _explosionTime);
        }
    }

    private void Explosion()
    {
        Debug.Log("Explosion");
        var colliders = Physics.OverlapSphere(transform.position, _explosionRadius);
        foreach (var collider in colliders)
        {
            if (collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("Enemy"))
            {
                collider.GetComponent<ITakeDamage>().TakeDamage(_explosionDamage);
                Destroy(gameObject);
            }
        }
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, _explosionRadius);
    }
}
