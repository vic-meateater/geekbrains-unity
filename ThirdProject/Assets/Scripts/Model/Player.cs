using System.Collections;
using UnityEngine;

namespace BananaMan
{
    public sealed class Player : PlayerActions
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private GameObject _bulletPref;
        [SerializeField] private Transform _bulletStartPosition;
        
        
        private int _animatorHashX;
        private int _animatorHashZ;
        private void Awake()
        {
            _animatorHashX = Animator.StringToHash("VelocityX");
            _animatorHashZ = Animator.StringToHash("VelocityZ");
        }
        private void Update()
        {
            //AimTowardMouse();
            // if(Input.GetKeyDown(KeyCode.Mouse0))
            //    Fire();
        }

        public override void MovePlayer(float moveX, float moveY, float moveZ)
        {
           
            Vector3 movement = new Vector3(moveX, moveY, moveZ);
            
            if(movement.magnitude > 0)
            {
                movement.Normalize();
                movement *= movementSpeed * Time.deltaTime;
                transform.Translate(movement, Space.World);
            }
            
            var velocityZ = Vector3.Dot(movement.normalized, transform.forward);
            var velocityX = Vector3.Dot(movement.normalized, transform.right);
            
            _animator.SetFloat(_animatorHashZ, velocityZ, 0.1f, Time.deltaTime);
            _animator.SetFloat(_animatorHashX, velocityX, 0.1f, Time.deltaTime);
        }

        public override void AimTowardMouse()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out var hit, Mathf.Infinity, _layerMask))
            {
                var direction = hit.point - transform.position;
                direction.y = 0f;
                direction.Normalize();
                transform.forward = direction;
            }
        }

        public override void Fire()
        {
            StartCoroutine(FireTimer(2f));
        }

        private IEnumerator FireTimer(float deltatimer)
        {
            var bulletInstantiate = Instantiate(_bulletPref, _bulletStartPosition.position, transform.rotation);
            bulletInstantiate.GetComponent<RifleBullet>().Init();
            yield return new WaitForSeconds(2f);
        }
        public override void SpeedUp(int value)
        {
            StartCoroutine(SpeedUpTimer(value));
        }

        private IEnumerator SpeedUpTimer(int timer)
        {
            movementSpeed += timer;
            yield return new WaitForSeconds(timer);
            movementSpeed -= timer;   
        }
    }
}