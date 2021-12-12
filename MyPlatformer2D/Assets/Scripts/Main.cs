using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer2D
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private int _animationSpeed = 15;
        [SerializeField] private LevelObjectView _playerView;

        private SpriteAnimatorController _playerAnimator;
        
        void Start()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            _playerAnimator = new SpriteAnimatorController(_playerConfig);
            
            _playerAnimator.StartAnimation(_playerView._spriteRenderer,AnimState.Walk,true,_animationSpeed);
        }

        void Update()
        {
            _playerAnimator.Update();
        }
    }
}
