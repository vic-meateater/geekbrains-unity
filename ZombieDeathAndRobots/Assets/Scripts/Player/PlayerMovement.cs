using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //VARIABLES
    [SerializeReference] private float _moveSpeed;
    [SerializeReference] private float _walkSpeed;
    [SerializeReference] private float _runSpeed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private GameObject _bulletPref, _minePref;
    [SerializeField] private Transform _bulletStartPosition, _minePlantPosition;
    [SerializeField] private AudioSource _playShoot;


    private Vector3 _moveDirection;
    private Vector3 _velocity;

    [SerializeField] private bool _isGrounded;
    [SerializeField] private float _groundCheckDistance;
    [SerializeField] private LayerMask _groundMask;
    private float _gravity = -9.8196f;



    //REFERENCES
    private CharacterController _Controller;
    private Animator _Animator;
    private Player _Player;

    void Start()
    {
        _Controller = GetComponent<CharacterController>();
        _Animator = GetComponentInChildren <Animator>();
        _Player = GetComponent<Player>();
    }

    void Update()
    {
        MovePlayer();
        PlayerShoot();
    }

    private void MovePlayer()
    {
        _isGrounded = Physics.CheckSphere(transform.position, _groundCheckDistance, _groundMask);

        
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        var moveX = Input.GetAxis("Horizontal");
        var moveZ = Input.GetAxis("Vertical");
        _moveDirection = new Vector3(moveX, 0, moveZ);
        _moveDirection = transform.TransformDirection(_moveDirection);

        if (_isGrounded)
        {
            if (_moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
            else if (_moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (_moveDirection == Vector3.zero)
            {
                Idle();
            }
            _moveDirection *= _moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump(_jumpHeight);
            }
        
        }
        _Controller.Move(_moveDirection * Time.deltaTime);

        _velocity.y += _gravity * Time.deltaTime;
        _Controller.Move(_velocity * Time.deltaTime);
    }

    private void PlayerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Shoot());
            _Player.UpdateAmmo(1);
            _playShoot.Play();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            MinePlant();
        }
    }
    private void Idle()
    {
        _Animator.SetFloat("Move", 0, 0.1f, Time.deltaTime);
    }
    private void Walk()
    {
        _moveSpeed = _walkSpeed;
        _Animator.SetFloat("Move", 0.33f, 0.1f, Time.deltaTime);
    }
    private void Run()
    {
        _moveSpeed = _runSpeed;
        _Animator.SetFloat("Move", 0.66f, 0.1f, Time.deltaTime);
    }
    public void Jump(float jumpHeight)
    {
        _velocity.y = Mathf.Sqrt(jumpHeight * -2 * _gravity);
        _Animator.SetFloat("Move", 1);
    }

    private IEnumerator Shoot()
    {
        _Animator.SetLayerWeight(_Animator.GetLayerIndex("Shooting Layer"), 1);
        _Animator.SetTrigger("Shooting");
        //var bulletInstantiate = Instantiate(_bulletPref, _bulletStartPosition.position, Quaternion.identity);
        var bulletInstantiate = Instantiate(_bulletPref, _bulletStartPosition.position, transform.rotation);
        var bullet = bulletInstantiate.GetComponent<OneBullet>();
        bullet.Init();
        yield return new WaitForSeconds(0.4f);
        _Animator.SetLayerWeight(_Animator.GetLayerIndex("Shooting Layer"), 0);

    }
    private void MinePlant()
    {
        var mine = Instantiate(_minePref, _minePlantPosition.position, Quaternion.identity);
        var initMine = mine.GetComponent<Mine>();
        initMine.Init();
    }
}

