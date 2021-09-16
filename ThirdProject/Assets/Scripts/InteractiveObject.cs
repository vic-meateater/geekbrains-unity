using System;
using UnityEngine;
using Random = UnityEngine.Random;
namespace BananaMan
{
    public abstract class InteractiveObject:MonoBehaviour, IComparable<InteractiveObject>, IInteractable
    {
        public bool IsInteractable { get; } = true;
        protected abstract void Interaction();

        private void Start()
        {
            Action();
        }

        public void Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Random.ColorHSV();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Debug.Log("Enter to Trigger");
            Interaction();
            Destroy(gameObject);
        }

        public int CompareTo(InteractiveObject other)
        {
            return name.CompareTo(other.name);
        }
    }
}