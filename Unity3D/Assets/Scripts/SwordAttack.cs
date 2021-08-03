using System;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _range;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            AttackSword();
        }
    }

    private void AttackSword()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _range))
        {
            Debug.Log(hit.collider.tag);
            Ememies ememies = hit.collider.GetComponentInParent<Ememies>();
            if (hit.collider.CompareTag("Enemy"))
            {
                ememies.TakeDamage(_damage, hit);
            }
        }
    }
}
