using System;
using UnityEngine;
namespace BananaMan
{
    public abstract class InteractiveObject:MonoBehaviour, IComparable<InteractiveObject>
    {
        protected abstract void Interaction();

        public bool IsInteractable { get; } = true;

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Debug.Log("Enter to Trigger");
            Destroy(gameObject);
        }

        public int CompareTo(InteractiveObject other)
        {
            return name.CompareTo(other.name);
        }
    }
}