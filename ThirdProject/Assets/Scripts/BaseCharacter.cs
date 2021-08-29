using UnityEngine;

namespace BananaMan
{
    public abstract class BaseCharacter : MonoBehaviour, ITakeDamage
    {
        [SerializeField] private int _maxHealth = 30;
        [SerializeField] protected float _movementSpeed = 3f;
        private int _currentHealth;

        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
        }
    }
}
