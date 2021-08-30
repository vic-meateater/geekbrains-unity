using UnityEngine;

namespace BananaMan
{
    public abstract class BaseCharacter : MonoBehaviour, ITakeDamage
    {
        [SerializeField] private int _maxHealth = 30;
        [SerializeField] protected float _movementSpeed;
        protected int _currentHealth;
        
        public Animator _animator;
        
        protected virtual void Start()
        {
            _currentHealth = _maxHealth;
            _animator = GetComponentInChildren<Animator>();
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
        }
    }
}
