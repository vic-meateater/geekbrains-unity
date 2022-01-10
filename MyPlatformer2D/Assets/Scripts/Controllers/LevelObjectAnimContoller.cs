using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer2D
{
    public class LevelObjectAnimContoller
    {
        private List<LevelObjectView> _objectPointsViews;
        private SpriteAnimatorController _objectAnimator;
        private float _animationSpeed = 10f;


        public LevelObjectAnimContoller(List<LevelObjectView> objectPointsViews, SpriteAnimatorController objectAnimator)
        {
            _objectPointsViews = objectPointsViews;
            _objectAnimator = objectAnimator;

            foreach (LevelObjectView objectView in _objectPointsViews)
            {
                _objectAnimator.StartAnimation(objectView._spriteRenderer, AnimState.Idle, true, _animationSpeed);
            }
        }

        public void Update()
        {
            _objectAnimator.Update();
        }
    }
}
