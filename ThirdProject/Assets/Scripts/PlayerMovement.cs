using UnityEngine;

namespace BananaMan
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _speed;
        private int _animantorHashX;
        private int _animantorHashZ;

        Animator _animator;



        //void Awake() => _animator = GetComponent<Animator>();
        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _animantorHashX = Animator.StringToHash("VelocityX");
            _animantorHashZ = Animator.StringToHash("VelocityZ");

        }
        private void Update()
        {
            MovePlayer();
            AimTowardMouse();
        }

        private void MovePlayer()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");


            Vector3 movement = new Vector3(moveX, 0f, moveZ);

            if(movement.magnitude > 0)
            {
                movement.Normalize();
                movement *= _speed * Time.deltaTime;
                transform.Translate(movement, Space.World);
            }

            float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
            float velocityX = Vector3.Dot(movement.normalized, transform.right);

            _animator.SetFloat(_animantorHashZ, velocityZ, 0.1f, Time.deltaTime);
            _animator.SetFloat(_animantorHashX, velocityX, 0.1f, Time.deltaTime);
        }

        private void AimTowardMouse()
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
    }
}

