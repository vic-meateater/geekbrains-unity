using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace BananaMan
{
    public abstract class EnemyActions : BaseCharacter
    {
        public bool IsDied = false;
        public void ChasePlayer(bool isDied, NavMeshAgent navMeshAgent, Transform player)
        {
           if (!isDied)
           {
               navMeshAgent.SetDestination(player.transform.position);    
           }
        }
        public virtual void Die(NavMeshAgent navMeshAgent)
        {
            IsDied = true;
            navMeshAgent.enabled = false;
        }
    }
}

