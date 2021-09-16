using System;
using UnityEngine;
using random = UnityEngine.Random;

namespace BananaMan
{

    public class BadBonus : InteractiveObject, IFly, IRotation
    {

        private float _flyHeight;
        private float _speedRotation;

        private void Awake()
        {
            _flyHeight = random.Range(1.0f, 5.0f);
            _speedRotation = random.Range(10.0f, 50.0f);
        }
        protected override void Interaction()
        {
            //
        }
        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                                                Mathf.PingPong(Time.time, _flyHeight),
                                                  transform.localPosition.z);
        }
        
        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }
    }
}
