using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer2D
{
    public class CoinController: IDisposable
    {
        private LevelObjectView _playerView;
        private SpriteAnimatorController _coinAnimator;
        private List<LevelObjectView> _coinViews;

        private float _animationSpeed = 10f;
        
        public CoinController(LevelObjectView player, SpriteAnimatorController animator, List<LevelObjectView> coinViews)
        {
            _playerView = player;
            _coinAnimator = animator;
            _coinViews = coinViews;

            _playerView.OnLevelObjectContact += OnLevelObjectContact;
            
            foreach (LevelObjectView coinView in coinViews)
            {
                _coinAnimator.StartAnimation(coinView._spriteRenderer, AnimState.Idle, true, _animationSpeed);
            }
        }

        public void Update()
        {
            _coinAnimator.Update();
        }
        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_coinViews.Contains(contactView))
            {
                _coinAnimator.StopAnimation(contactView._spriteRenderer);
                GameObject.Destroy(contactView.gameObject);
            }
        }
        public void Dispose()
        {
            _playerView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}