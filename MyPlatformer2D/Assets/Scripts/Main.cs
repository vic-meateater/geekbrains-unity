using UnityEngine;

namespace MyPlatformer2D
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        //[SerializeField] private int _animationSpeed = 15;
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private Transform _camera;
        [SerializeField] private Transform _background;
        [SerializeField] private CannonView _cannonView;


        private SpriteAnimatorController _playerAnimator;
        private PlayerController _playerController;
        private ParalaxManager _paralaxManager;
        private CameraController _cameraController;
        private CannonAimController _cannon;
        public BulletEmitterController _bulletEmitterController;


        void Start()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            _playerAnimator = new SpriteAnimatorController(_playerConfig);
            _playerController = new PlayerController(_playerView, _playerAnimator);
            _paralaxManager = new ParalaxManager(_camera, _background);
            _cameraController = new CameraController(_playerView, Camera.main.transform);
            _cannon = new CannonAimController(_cannonView._muzzleTransform, _playerView.transform);
            _bulletEmitterController = new BulletEmitterController(_cannonView._bullets, _cannonView._emitterTransform);
        }

        void Update()
        {
            _cameraController.Update();
            _playerController.Update();
            _paralaxManager.Update();
            _cannon.Update();
            _bulletEmitterController.Update();
        }
    }
}
