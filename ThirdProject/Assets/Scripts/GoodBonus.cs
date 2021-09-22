using System;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;

namespace BananaMan
{
    public sealed class GoodBonus : InteractiveObject, IFly, IFlicker, ICloneable
    {
        private Player _player;
        private Material _material;
        private float _flyHeight;
        private int _respawnTime;

        private void Awake()
        {
            _material = GetComponent<Renderer>().sharedMaterial;
            _flyHeight = Random.Range(1.0f, 5.0f);
            _player = FindObjectOfType<Player>();
            _respawnTime = Random.Range(5, 60);

        }

        protected override void Interaction()
        {
            _player.SpeedUp(5);
            //Где правильно вызывать корутину? 
            //StartCoroutine(RespawnGoodBonus(5));
            StartCoroutine(Respawn(5f));

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

        private IEnumerator RespawnGoodBonus(int timer)
        {
            Debug.Log("Before");
            yield return new WaitForSeconds(timer);
            Debug.Log("After");
            Clone();
        }
        
        private IEnumerator Respawn(float timer)
        {
            int timeOut = 0;
            while (timeOut != timer)
            {
                timeOut++;
                if (timeOut == timer)
                {
                    Clone();
                }
                yield return new WaitForSeconds(1f);
            }
        }

        public object Clone()
        {
            var result = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
            return result;

        }

    }
}

