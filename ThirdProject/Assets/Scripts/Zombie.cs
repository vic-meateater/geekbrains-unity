namespace BananaMan
{
    public class Zombie : EnemyActions
    {
        private void Update()
        {
            ChasePlayer(IsDied);
            Die();
        }

        protected override void Die()
        {
            if (CurrentHealth <= 0)
            {
                base.Die();
                _animator.SetTrigger("DieTrigger");
            }

        }
    }
}
