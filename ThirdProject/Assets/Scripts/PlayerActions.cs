using UnityEngine;

namespace BananaMan
{
    public abstract class PlayerActions : BaseCharacter
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
        public void MovePlayer()
        {
            var moveX = Input.GetAxis("Horizontal");
            var moveZ = Input.GetAxis("Vertical");


            Vector3 movement = new Vector3(moveX, 0f, moveZ);

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

        public void AimTowardMouse()
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

        protected void Fire()
        {
            var bulletInstantiate = Instantiate(_bulletPref, _bulletStartPosition.position, transform.rotation);
            bulletInstantiate.GetComponent<RifleBullet>().Init();
        }

        public void SpeedUp(int value)
        {
            movementSpeed += value;
        }
    }
}

