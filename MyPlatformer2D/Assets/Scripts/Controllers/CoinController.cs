using UnityEngine;

namespace MyPlatformer2D
{
    public class CoinController
    {
        private LevelObjectView _view;
        private SpriteAnimatorController _coinAnimator;
        private readonly ContactPooler _contactPooler;

        private float _animationSpeed = 10f;
        
        public CoinController(LevelObjectView player, SpriteAnimatorController animator)
        {
            _view = player;
            _coinAnimator = animator;
            _coinAnimator.StartAnimation(_view._spriteRenderer, AnimState.Idle, true, _animationSpeed);
            _contactPooler = new ContactPooler(_view._collider);
        }

        public void Update()
        {
            _coinAnimator.Update();
        }
    }
}