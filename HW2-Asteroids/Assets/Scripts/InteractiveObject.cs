using UnityEngine;

namespace Asteroids
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable
    {
        private bool _isInteractable;
        protected Player Player;

        private void Start()
        {
            Player = FindObjectOfType<Player>();
            _isInteractable = true;
        }

        public bool IsInteractable
        {
            get { return _isInteractable; }
            private set
            {
                _isInteractable = value;
                gameObject.SetActive(_isInteractable);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!IsInteractable || !collision.gameObject.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            IsInteractable = false;
        }

        protected abstract void Interaction();
    }
}