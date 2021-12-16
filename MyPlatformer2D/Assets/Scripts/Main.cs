using UnityEngine;

namespace MyPlatformer2D
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private int _animationSpeed = 15;
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private Transform _camera;
        [SerializeField] private Transform _background;


        private SpriteAnimatorController _playerAnimator;
        private PlayerController _playerController;
        private ParalaxManager _paralaxManager;
        
        void Start()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            _playerAnimator = new SpriteAnimatorController(_playerConfig);
            _playerController = new PlayerController(_playerView, _playerAnimator);
            _paralaxManager = new ParalaxManager(_camera, _background);
        }

        void Update()
        {
            _playerController.Update();
            _paralaxManager.Update();
        }
    }
}
