using UnityEngine;

public class Turell : MonoBehaviour
{
    //VARIABLES
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _turellHead;
    [SerializeField] private float _turretRange = 9f;


    [SerializeField] private float _fireRate = 10f;
    private float _fireCountDown = 0f;
    private float _speed = 3f;
    
   
    void Update()
    {
        CheckPlayerInRange();
    }

    private void CheckPlayerInRange()
    {
        
        var distanceToPlayer = Vector3.Distance(transform.position, _target.transform.position);
        if (distanceToPlayer < _turretRange)
        {
            TurnHead();
        }
        if (distanceToPlayer <= _turretRange - 1.5f)
        {
            if (_fireCountDown < 0f)
            {
                Fire();
                _fireCountDown = 1f / _fireRate;
            }
            _fireCountDown -= Time.deltaTime;
        }
        
    }
    private void TurnHead()
    {
        var pos = _target.position - _turellHead.position;
        var rot = Vector3.RotateTowards(_turellHead.forward, pos, _speed * Time.deltaTime, 0.0f);
        _turellHead.rotation = Quaternion.LookRotation(rot);
    }
    private void Fire()
    {
        Debug.Log("Turell shooting");
        var bulletInstantiate = Instantiate(_bullet, _startPosition.position, _turellHead.rotation);
        var bullet = bulletInstantiate.GetComponent<OneBullet>();
        bullet.Init();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, _turretRange);
    }
}
