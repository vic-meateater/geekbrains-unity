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

        Animator _animator;
        private void Start() => _animator = GetComponentInChildren<Animator>();
        private void Awake()
        {
            _animatorHashX = Animator.StringToHash("VelocityX");
            _animatorHashZ = Animator.StringToHash("VelocityZ");
        }
        public void MovePlayer()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");


            Vector3 movement = new Vector3(moveX, 0f, moveZ);

            if(movement.magnitude > 0)
            {
                movement.Normalize();
                movement *= _movementSpeed * Time.deltaTime;
                transform.Translate(movement, Space.World);
            }

            float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
            float velocityX = Vector3.Dot(movement.normalized, transform.right);

            _animator.SetFloat(_animatorHashZ, velocityZ, 0.1f, Time.deltaTime);
            _animator.SetFloat(_animatorHashX, velocityX, 0.1f, Time.deltaTime);
        }

        public void AimTowardMouse()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out var hit, Mathf.Infinity, _layerMask))
            {
                var _direction = hit.point - transform.position;
                _direction.y = 0f;
                _direction.Normalize();
                transform.forward = _direction;
            }
        }

        public void Shoot()
        {
            Instantiate(_bulletPref, _bulletStartPosition.position, transform.rotation);
        }
    }
}

