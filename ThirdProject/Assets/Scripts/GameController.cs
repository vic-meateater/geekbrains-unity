using UnityEngine;

namespace BananaMan
{
    public class GameController : MonoBehaviour
    {
        private InteractiveObject[] _interactiveObjects;

        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
        }

        private void Update()
        {
            foreach (var interactiveObject in _interactiveObjects)
            {
                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IFly fly)
                {
                    fly.Fly();
                }

                if (interactiveObject is IRotation rotation)
                {
                    rotation.Rotation();
                }

                if (interactiveObject is IFlicker flicker)
                {
                    flicker.Flicker();
                }
            }
        }
    }
}