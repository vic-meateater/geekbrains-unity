using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;

    private float _gravity => -9.81f;
    private float _groundDistance => 0.4f;

    private Animator _animator;
    private Vector3 _velocity;
    private bool _isGrounded;
    private int _isAttackTriggerHash;
    private int _velocityHash;
    
    //Walk,run speed settings
    private float _acceleration => 0.5f;
    private float _deceleration => 0.6f;
    private float _speed = 5.0f;

    //Attack settings
    private float _attackRate => 1.1f;
    private float _coolDownAttackTime;



    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _velocityHash = Animator.StringToHash("Velocity");
        _isAttackTriggerHash = Animator.StringToHash("isAttackTrigger");
    }
    private void Update()
    {
        PlayerMovements();
        PlayerAttack();

    }
    void PlayerMovements()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);
        if (_isGrounded && _velocity.y < 0)
            _velocity.y = -2f;

        var moveX = Input.GetAxis("Horizontal");
        var moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        _controller.Move(move * _speed * Time.deltaTime);
        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);

        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        if (move != Vector3.zero && _velocity.z < 0.1f)
        {
            _velocity.z = 0.1f;
        }
        if (move != Vector3.zero && _velocity.z < 1.0f && runPressed)
        {
            _velocity.z += Time.deltaTime * _acceleration;
            _speed += Time.deltaTime * _acceleration * 10;
        }
        if (move != Vector3.zero && _velocity.z > 0.1f && !runPressed)
        {
            _velocity.z -= Time.deltaTime * _deceleration;
            _speed -= Time.deltaTime * _deceleration * 10;
        }
        if (move == Vector3.zero)
        {
            _velocity.z = 0.0f;
            _speed = 5.0f;
        }
        _animator.SetFloat(_velocityHash, _velocity.z);
    }
    private void PlayerAttack()
    {
        if (Time.time >= _coolDownAttackTime){
            if (Input.GetButtonDown("Fire1"))
            {
                transform.GetComponentInChildren<SwordAttack>().Slash();
                _coolDownAttackTime = Time.time + _attackRate;
                StartCoroutine(SwordAttackAnimation());
            }
        }
    }
    private IEnumerator SwordAttackAnimation()
    {
        _animator.SetLayerWeight(_animator.GetLayerIndex("Attack Layer"), 1);
        _animator.SetTrigger(_isAttackTriggerHash);
        yield return new WaitForSeconds(_attackRate);
        _animator.SetLayerWeight(_animator.GetLayerIndex("Attack Layer"), 0);
    }
}
