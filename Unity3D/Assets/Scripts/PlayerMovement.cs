using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speed;
    private float _gravity => -9.81f;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;
    private float _groundDistance => 0.4f;

    private Animator _animator;
    private Vector3 _velocity;
    private bool _isGrounded;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        PlayerMovements();
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

        if (move != Vector3.zero)
        {
            PlayerWalk();
        }
        else if (move == Vector3.zero)
        {
            PlayerIdle();
        }

    }

    void PlayerWalk()
    {
        _animator.SetBool("isWalking", true);
    }

    void PlayerIdle()
    {
        _animator.SetBool("isWalking", false);
    }
}
