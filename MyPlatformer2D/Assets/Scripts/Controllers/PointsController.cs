using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer2D
{
    public class PointsController: IDisposable
    {

        private Transform _startPoint;
        private List<LevelObjectView> _returnPointsViews;
        private LevelObjectView _playerView;
        private SpriteAnimatorController _portalAnimator;
        
        private float _animationSpeed = 5f;

        public PointsController(LevelObjectView playerView, List<LevelObjectView> returnPointsViews, Transform startPoint, SpriteAnimatorController portalAnimator)
        {
            
            _startPoint = startPoint;
            _returnPointsViews = returnPointsViews;
            _playerView = playerView;
            _portalAnimator = portalAnimator;
            
            _playerView.OnLevelObjectContact += OnLevelObjectContact;
            foreach (LevelObjectView portalView in _returnPointsViews)
            {
                _portalAnimator.StartAnimation(portalView._spriteRenderer, AnimState.Idle, true, _animationSpeed);
            }
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_returnPointsViews.Contains(contactView))
            {
                _playerView.transform.position = _startPoint.position;
            }
        }
        
        public void Update()
        {
            _portalAnimator.Update();
        }

        public void Dispose()
        {
            _playerView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}