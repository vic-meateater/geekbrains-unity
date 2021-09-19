using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BananaMan
{
    public sealed class GoodBonus : InteractiveObject, IFly, IFlicker
    {
        private Player _player;
        private Material _material;
        private float _flyHeight;

        private void Awake()
        {
            _material = GetComponent<Renderer>().sharedMaterial;
            //_material = GetComponent<Renderer>().material;
            _flyHeight = Random.Range(1.0f, 5.0f);
            _player = FindObjectOfType<Player>();
            
        }

        protected override void Interaction()
        {
            _player.SpeedUp(5);
            Debug.Log("1");

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

