using UnityEngine.AI;

namespace BananaMan
{
    public class Zombie : EnemyActions
    {
        public override void Die(NavMeshAgent navMeshAgent)
        {
            if (CurrentHealth > 0) return;
            base.Die(navMeshAgent);
            _animator.SetTrigger("DieTrigger");

        }
    }
}
