using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer2D
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private SpriteAnimatorConfig _coinConfig;
        [SerializeField] private SpriteAnimatorConfig _portalConfig;
        //[SerializeField] private LevelObjectView _coinView;
        [SerializeField] private Transform _camera;
        [SerializeField] private Transform _background;
        [SerializeField] private Transform _midBackground;
        [SerializeField] private Transform _frontBackground;
        [SerializeField] private CannonView _cannonView;
        [SerializeField] private List<LevelObjectView> _coinViews;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private List<LevelObjectView> _returnPointsViews;


        private SpriteAnimatorController _playerAnimator;
        private SpriteAnimatorController _coinAnimator;
        private SpriteAnimatorController _portalAnimator;
        private PlayerController _playerController;
        private ParalaxManager _paralaxManager;
        private CameraController _cameraController;
        private CannonAimController _cannon;
        private BulletEmitterController _bulletEmitterController;
        private CoinController _coinController;
        private PointsController _pointsController;
        


        void Start()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            _playerAnimator = new SpriteAnimatorController(_playerConfig);
            _playerController = new PlayerController(_playerView, _playerAnimator);
            _coinConfig = Resources.Load<SpriteAnimatorConfig>("CoinAnimCfg");
            _coinAnimator = new SpriteAnimatorController(_coinConfig);
            _coinController = new CoinController(_playerView, _coinAnimator, _coinViews);
            _portalConfig = Resources.Load<SpriteAnimatorConfig>("PortalAnimConfig");
            _portalAnimator = new SpriteAnimatorController(_portalConfig);
            _pointsController = new PointsController(_playerView, _returnPointsViews, _startPoint, _portalAnimator);
            _paralaxManager = new ParalaxManager(_camera, _background, _midBackground, _frontBackground);
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
            _coinController.Update();
            //_coinAnimator.Update();
            _pointsController.Update();
        }
    }
}
