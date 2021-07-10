
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour, ITakeDamage
{
    ///VARIABLES
    private int _hp;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _playerStatusMenu;
    [SerializeField] private TextMeshProUGUI _playerStatus;

    int m_CurrentWaypointIndex;
    [SerializeField] private LayerMask _whatIsGround, _whatIsPlayer;

    //Patroling
    [SerializeField] private Vector3 _wayPoint, _prevTransformPosition;
    private bool _wayPointSet = false;

    [SerializeField] private float _walkPointRange = 2;

    //Attacking
    [SerializeField] private float _timeBetweenAttacks;
    //bool _alreadyAttacked;
    [SerializeField] private float _attackCountDown;
    [SerializeField] private float _attackRate;

    //States
    [SerializeField] private float _sightRange, _attackRange;
    [SerializeField] private bool _playerInSightRange, _playerInAttackRange;
    private bool _zombieIsDead = false;


    ///REFERENCES
    private Animator _Animator;
    private NavMeshAgent _NavMeshAgent;
    private Player _PlayerStatus;


    void Start()
    {
        _player = GameObject.Find("Player").transform;
    }

    private void Awake()
    {
        _Animator = GetComponentInChildren<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();

        _hp = 500;
    }

    private void Update()
    {
        _playerInSightRange = Physics.CheckSphere(transform.position, _sightRange, _whatIsPlayer);
        _playerInAttackRange = Physics.CheckSphere(transform.position, _attackRange, _whatIsPlayer);
        if (!_zombieIsDead)
        {
            if (_playerInSightRange && _playerInAttackRange)
            {
                AttackPlayer();
                Attack();
            }
            if (_playerInSightRange && !_playerInAttackRange)
            {
                ChasePlayer();
                    Runing();
            }
            if (!_playerInSightRange && !_playerInAttackRange)
            {
                Patroling();
                Walking();
            }
        }
        else
        {
            Death();
        }
    }
    private void Patroling()
    {
        if (_prevTransformPosition == transform.position)
            _wayPointSet = false;
        if (!_wayPointSet) SearchWalkPoint();

        if (_wayPointSet)
            _navMeshAgent.SetDestination(_wayPoint);

        Vector3 distanceToWalkPoint = transform.position - _wayPoint;

        //Waypoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            _wayPointSet = false;

        _prevTransformPosition = transform.position;

    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-_walkPointRange, _walkPointRange);
        float randomX = Random.Range(-_walkPointRange, _walkPointRange);
        _wayPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        _wayPointSet = true;
    }

    private void ChasePlayer()
    {
        _navMeshAgent.SetDestination(_player.position);
    }
    private void AttackPlayer()
    {
        //Stopping zombie
        _navMeshAgent.SetDestination(transform.position);

        transform.LookAt(_player);

        if (_attackCountDown < 0f)
        {

            _attackCountDown = 1f / _attackRate;
            _player.GetComponent<Player>().TakeDamage(75);
        }
        _attackCountDown -= Time.deltaTime;
    }
    public void DestroyEnemy()
    {
        Destroy(gameObject, 2f);
    }
    private void Walking()
    {
        _Animator.SetFloat("Move", 0.16f, 0.1f, Time.deltaTime);
        _navMeshAgent.speed = 0.25f;
    }
    private void Runing()
    {
        _Animator.SetFloat("Move", 0.33f, 0.1f, Time.deltaTime);
        _navMeshAgent.speed = 5f;
    }

    private void Attack()
    {
        _Animator.SetFloat("Move", 0.5f, 0.1f, Time.deltaTime);
        _navMeshAgent.speed = 0f;

    }
    public void Death()
    {
        _navMeshAgent.SetDestination(transform.position);
        _Animator.SetFloat("Move", 0.66f, 0.1f, Time.deltaTime);
        DestroyEnemy();

    }
    public void TakeDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            Debug.Log("arrrghhh!");
            _zombieIsDead = true;
            Invoke("StatusMenu",2);


        }
    }

    private void StatusMenu()
    {
        Time.timeScale = 0f;
        _playerStatusMenu.SetActive(true);
        _playerStatus.text = "You WIN!!";
        Cursor.lockState = CursorLockMode.Confined;
    }
}
