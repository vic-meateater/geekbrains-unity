using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using random = UnityEngine.Random;

namespace BananaMan
{

    public class BadBonus : InteractiveObject, IFly, IRotation, ICloneable
    {

        private float _flyHeight;
        private float _speedRotation;
        private Player _player;

        private void Awake()
        {
            _flyHeight = random.Range(1.0f, 5.0f);
            _speedRotation = random.Range(10.0f, 50.0f);
            _player = FindObjectOfType<Player>();
        }
        protected override void Interaction()
        {
            Destroy(_player.gameObject);
            SceneManager.LoadScene("SampleScene");
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

        public object Clone()
        {
            var result = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
            return result;
        }
    }
}
