using UnityEngine;

namespace MyPlatformer2D
{
    public class PlayerController
    {
        private float _xAxisInput;
        private bool _isJump;
        private bool _isMoving;

        private float _walkSpeed = 3f;
        private float _animationSpeed = 10f;
        private float _movingTreshold = 0.1f;
        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);

        private float _jumpSpeed = 9f;
        private float _jumpTreshold = 1f;
        private float _gravity = -9.8f;
        private float _groundLevel = 0.5f;
        private float _yVelocity = 0f;
        private float _xVelocity = 0f;

        private LevelObjectView _view;
        private SpriteAnimatorController _playerAnimator;
        private readonly ContactPooler _contactPooler;

        public PlayerController(LevelObjectView player, SpriteAnimatorController animator)
        {
            _view = player;
            _playerAnimator = animator;
            _playerAnimator.StartAnimation(_view._spriteRenderer, AnimState.Idle, true, _animationSpeed);
            _contactPooler = new ContactPooler(_view._collider);
        }

        private void MoveTowards()
        {
            _xVelocity = Time.fixedDeltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1);
            //_view._transform.position += Vector3.right * (Time.deltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1));
            //_view._rigidbody.velocity = _view._rigidbody.velocity.Change();// ��������
            _view._rigidbody.velocity = _view._rigidbody.velocity.Change();
            _view._transform.localScale = _xAxisInput < 0 ? _leftScale : _rightScale;
        }

        public bool IsGrounded()
        {
            return _view._transform.position.y <= _groundLevel && _yVelocity <= 0;
        }
        public void Update()
        {
            _playerAnimator.Update();
            _contactPooler.Update();
            _xAxisInput = Input.GetAxis("Horizontal");
            _isJump = Input.GetAxis("Vertical") > 0;
            _isMoving = Mathf.Abs(_xAxisInput) > _movingTreshold;

            if (_isMoving)
            {
                MoveTowards();
            }
            if (_contactPooler.IsGrounded)
            {
                _playerAnimator.StartAnimation(_view._spriteRenderer, _isMoving ? AnimState.Walk : AnimState.Idle, true, _animationSpeed);

                if(_isJump && Mathf.Abs(_view._rigidbody.velocity.y) <= _jumpTreshold)
                {
                    _view._rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
                }
                //else if (_yVelocity < 0)
                //{
                //    _yVelocity = 0f;

                //    _view.transform.position = _view._transform.position.Change(y: _groundLevel);

                //}
            }
            else
            {
                if(Mathf.Abs(_view._rigidbody.velocity.y) > _jumpTreshold)
                {
                    _playerAnimator.StartAnimation(_view._spriteRenderer, AnimState.Jump, true, _animationSpeed);
                }
            }
        }
    }
}
