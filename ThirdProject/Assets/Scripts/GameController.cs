using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BananaMan
{
    public class GameController : MonoBehaviour
    {
        private List<InteractiveObject> _interactiveObjects;

        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>().ToList();;
            var displayBonuses = new DisplayBonuses();
            foreach (var interactiveObject in _interactiveObjects)
            {
                interactiveObject.Initialization(displayBonuses);
                interactiveObject.OnDestroyChange += InteractiveObjectOnOnDestroyChange;
            }
        }
        
        private void InteractiveObjectOnOnDestroyChange(InteractiveObject value)
        {
            value.OnDestroyChange -= InteractiveObjectOnOnDestroyChange;
            _interactiveObjects.Remove(value);
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