using UnityEngine;
using random = UnityEngine.Random;

namespace BananaMan
{
    public class WinBonus : InteractiveObject, IFly, IRotation
    {
        private DisplayBonuses _displayBonuses;
        private float _flyHeight;
        private float _speedRotation;

        private void Awake()
        {
            _flyHeight = random.Range(1.0f, 5.0f);
            _speedRotation = random.Range(10.0f, 50.0f);
            _displayBonuses = new DisplayBonuses();
        }
        
        protected override void Interaction()
        {
            _displayBonuses.Display(1);
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

