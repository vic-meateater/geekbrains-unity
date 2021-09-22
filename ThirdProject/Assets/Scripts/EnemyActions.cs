using UnityEngine;
using UnityEngine.AI;

namespace BananaMan
{
    public abstract class EnemyActions : BaseCharacter
    {
        private NavMeshAgent _navMeshAgent;
        private Transform _player;
        protected bool IsDied = false;

        protected override void Start()
        {
            base.Start();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _player = FindObjectOfType<Player>().transform;
        }

        protected void ChasePlayer(bool isDied)
        {
            if (!isDied)
            {
                _navMeshAgent.SetDestination(_player.transform.position);    
            }
        }

        protected virtual void Die()
        {
            IsDied = true;
            _navMeshAgent.enabled = false;
        }
    }
}

