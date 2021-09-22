using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BananaMan
{
    public abstract class InteractiveObject:MonoBehaviour, IComparable<InteractiveObject>, IInteractable
    {
        protected IView _view;
        public event Action<InteractiveObject> OnDestroyChange;
        public bool IsInteractable { get; } = true;
        protected abstract void Interaction();

        private void Start()
        {
            ((IAction)this).Action();
        }

        public void Action()
        {
            if (TryGetComponent(out Renderer r))
            {
                r.material.color = Random.ColorHSV();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            OnDestroyChange?.Invoke(this);
            Destroy(gameObject);
        }

        public int CompareTo(InteractiveObject other)
        {
            return name.CompareTo(other.name);
        }

        public void Initialization(IView view)
        {
            _view = view;
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Color.cyan;
            }
        }
    }
}