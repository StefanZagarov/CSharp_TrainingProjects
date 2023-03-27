using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] protected float _detectRange;
    [SerializeField] protected float _stoppingDistance;

    protected GameObject _playerRef;
    protected NavMeshAgent _agent;

    protected Animator _animator;

    protected Vector3 _originalPosition;

    private Vector3 _oldPosition;
    private void Start()
    {
        _playerRef = GameObject.FindGameObjectWithTag("Player");

        _agent = GetComponent<NavMeshAgent>();        
        _animator = GetComponent<Animator>();

        _originalPosition = _agent.transform.position;
        _oldPosition = transform.position;
    }

    private void Update()
    {
        EnemyMove();
    }

    protected void EnemyMove()
    {
        //a formula to calculate if the object is moving
        float speed = Vector3.Distance(_oldPosition, transform.position) / Time.deltaTime;
        _oldPosition = transform.position;

        if (Vector3.Distance(_playerRef.transform.position, transform.position) < _detectRange
           && !GetComponent<RayCast>().IsBlocked(_playerRef))
        {
            MoveToPosition(_playerRef.transform.position, _stoppingDistance);
        }
        else
        {
            MoveToPosition(_originalPosition, 0);
        }

        if (speed > 0)
        {
            _animator.SetBool("isMoving", true);
        }
        else
        {
            _animator.SetBool("isMoving", false);
        }
    }

    private void MoveToPosition(Vector3 position, float stoppingDistance)
    {
        _agent.SetDestination(position);
        _agent.stoppingDistance = stoppingDistance;
    }

    //maybe stopping distance should activate only if player is visible

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _detectRange);
    }
}