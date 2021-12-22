using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer2D
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private SpriteAnimatorConfig _coinConfig;
        //[SerializeField] private LevelObjectView _coinView;
        [SerializeField] private Transform _camera;
        [SerializeField] private Transform _background;
        [SerializeField] private CannonView _cannonView;
        [SerializeField] private List<LevelObjectView> _coinViews;


        private SpriteAnimatorController _playerAnimator;
        private SpriteAnimatorController _coinAnimator;
        private PlayerController _playerController;
        private ParalaxManager _paralaxManager;
        private CameraController _cameraController;
        private CannonAimController _cannon;
        private BulletEmitterController _bulletEmitterController;
        private CoinController _coinController;
        


        void Start()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            _playerAnimator = new SpriteAnimatorController(_playerConfig);
            _playerController = new PlayerController(_playerView, _playerAnimator);
            _coinConfig = Resources.Load<SpriteAnimatorConfig>("CoinAnimCfg");
            _coinAnimator = new SpriteAnimatorController(_coinConfig);
            _coinController = new CoinController(_playerView, _coinAnimator, _coinViews);
            
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
            //_coinController.Update();
            _coinAnimator.Update();
        }
    }
}
