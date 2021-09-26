using UnityEngine;
using Random = UnityEngine.Random;

namespace BananaMan
{
    public abstract class InteractiveObject:MonoBehaviour, IExecute
    {
        protected Color _color;
        private bool _isInteractible;

        protected bool IsInteractable
        {
            get => _isInteractible;
            private set
            {
                _isInteractible = value;
                if(TryGetComponent(out Renderer rend)) rend.enabled = _isInteractible;
                if(TryGetComponent(out Collider coll)) coll.enabled = _isInteractible;
                GetComponentInChildren<Renderer>().enabled = _isInteractible;

            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            IsInteractable = false;
        }

        protected abstract void Interaction();
        public abstract void Execute();

        private void Start()
        {
            IsInteractable = true;
            _color = Random.ColorHSV();
            if (TryGetComponent(out Renderer render))
            {
                render.material.color = _color;
            }
        }

    }
}