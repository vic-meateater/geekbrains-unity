using System;
using UnityEngine;
using random = UnityEngine.Random;

namespace BananaMan
{
    public sealed class GoodBonus : InteractiveObject, IFly, IFlicker
    {
        private Material _material;
        private float _flyHeight;

        private void Awake()
        {
            _material = GetComponent<Renderer>().sharedMaterial;
            _flyHeight = random.Range(2f, 6f);
        }

        private void Update()
        {
            Fly();
            Flicker();
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
        public void Flicker()
        {
            _material.color = new Color(_material.color.r,
                                        _material.color.g,
                                        _material.color.b,
                                        Mathf.PingPong(Time.time, 1f));
        }



    }
}

