using UnityEngine;
using UnityEngine.AI;

namespace BananaMan
{
    public abstract class BaseCharacter : MonoBehaviour, ITakeDamage
    {
        [SerializeField] public int _maxHealth = 30;
        [SerializeField] public float movementSpeed;
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
