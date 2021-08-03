using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] private int _damage;
    [SerializeField] private float _range;
    [SerializeField] Camera _fpsCam;
    [SerializeField] ParticleSystem _shtootingFlash;

    private float _attackForce = 1500f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        _shtootingFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(_fpsCam.transform.position, _fpsCam.transform.forward, out hit, _range))
        {
            Enemy enemy = hit.collider.GetComponentInParent<Enemy>();
            if (hit.collider.CompareTag("Enemy"))
            {
                enemy.TakeDamage(_damage, hit, _fpsCam, _attackForce);
            }
        }
    }
}
