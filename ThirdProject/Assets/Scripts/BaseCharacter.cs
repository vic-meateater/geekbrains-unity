using UnityEngine;

namespace BananaMan
{
    public abstract class BaseCharacter : MonoBehaviour, ITakeDamage
    {
        [SerializeField] private int _maxHealth = 30;
        [SerializeField] protected float _movementSpeed;
        protected int CurrentHealth;
        
        public Animator _animator;
        
        protected virtual void Start()
        {
            CurrentHealth = _maxHealth;
            _animator = GetComponentInChildren<Animator>();
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
        }
    }
}
