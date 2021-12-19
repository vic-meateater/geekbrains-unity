using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer2D
{
    public class BulletEmitterController : MonoBehaviour
    {
        private List<BulletController> _bullets = new List<BulletController>();
        private Transform _transform;

        private int _currentIndex;
        private float _timeTillNextBullet;

        private float _delay = 1;
        private float _startSpeed = 5;

        public BulletEmitterController(List<LevelObjectView> bulletViews, Transform transform)
        {
            _transform = transform;
            foreach(LevelObjectView bulletView in bulletViews)
            {
                _bullets.Add(new BulletController(bulletView));
            }
        }

       public void Update()
        {
            if(_timeTillNextBullet > 0)
            {
                _bullets[_currentIndex].Active(false);
                _timeTillNextBullet -= Time.deltaTime;
            }
            else
            {
                _timeTillNextBullet = _delay;
                _bullets[_currentIndex].Throw(_transform.position, -_transform.up * _startSpeed);
                _currentIndex++;

                if(_currentIndex >= _bullets.Count)
                {
                    _currentIndex = 0;
                }
            }
        }
    }
}
