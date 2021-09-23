using System;
using UnityEngine;
using random = UnityEngine.Random;

namespace BananaMan
{
    public class WinBonus : InteractiveObject, IFly, IRotation, IEquatable<WinBonus>
    {
        public int Point;
        private DisplayBonuses _displayBonuses;
        private float _flyHeight;
        private float _speedRotation;

        private void Awake()
        {
            _flyHeight = random.Range(1.0f, 2.0f);
            _speedRotation = random.Range(10.0f, 30.0f);
        }
        
        protected override void Interaction()
        {
            //_view.Display(Point);
            _displayBonuses.Display(Point);
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                                                Mathf.PingPong(Time.time, _flyHeight),
                                                transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.down * (Time.deltaTime * _speedRotation), Space.World);
        }

        public bool Equals(WinBonus other)
        {
            return Point == other.Point;
        }
    }  
}

