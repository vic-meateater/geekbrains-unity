using System;
using UnityEngine;
using random = UnityEngine.Random;

namespace BananaMan
{
    public class WinBonus : InteractiveObject, IFly, IRotation
    {
        public int Point;
        public event Action<int> OnPointChanged = delegate(int i) { };
        private float _flyHeight;
        private float _speedRotation;

        private void Awake()
        {
            _flyHeight = random.Range(1.0f, 2.0f);
            _speedRotation = random.Range(10.0f, 30.0f);
        }
        
        protected override void Interaction()
        {
            OnPointChanged.Invoke(Point);
        }

        public override void Execute()
        {
            if (!IsInteractable)return;
            Fly();
            Rotation();
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
    }  
}

