using UnityEngine;
using UnityEngine.AI;

public class EnemyMoverSniper : EnemyMover
{
    private Vector3 _runAway;

    private void Update()
    {
        EnemyMove();

        RunAway();
    }

    private void RunAway()
    {
        if (Vector3.Distance(transform.position, _playerRef.transform.position) < _stoppingDistance / 1.5)
        {
            _runAway = transform.position + (transform.position - _playerRef.transform.position);
            _agent.SetDestination(_runAway);
            _agent.stoppingDistance = -_stoppingDistance;
        }

    }
}