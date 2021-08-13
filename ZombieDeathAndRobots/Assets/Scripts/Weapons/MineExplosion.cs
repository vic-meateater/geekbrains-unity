using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplosion : MonoBehaviour
{
    ///VARIABLES
    [SerializeField] private float _explosionTime = 1;
    [SerializeField] private float _explosionRadius = 2;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        Debug.Log(collision.gameObject.name);
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
            Debug.Log(collider.gameObject.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, _explosionRadius);
    }
}
