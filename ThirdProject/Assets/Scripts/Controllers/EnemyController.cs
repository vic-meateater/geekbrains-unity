using UnityEngine;
using UnityEngine.AI;

namespace BananaMan
{
    public class EnemyController:IExecute
    {
        private Zombie _zombie;
        private Transform _player;
        private NavMeshAgent _navMeshAgent;
        //protected int CurrentHealth;

        public EnemyController(Zombie zombie, Transform player)
        {
            _zombie = zombie;
            _player = player;
            _navMeshAgent = _zombie.gameObject.GetComponent<NavMeshAgent>();
        }
        public void Execute()
        {
            _zombie.ChasePlayer(_zombie.IsDied, _navMeshAgent, _player);
            _zombie.Die(_navMeshAgent);
        }
    }
}