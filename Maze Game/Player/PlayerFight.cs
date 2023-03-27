using UnityEngine;
using System.Collections.Generic;

public class PlayerFight : MonoBehaviour
{
    [SerializeField] private float _damage = 0f;
    [SerializeField] private float _attackRange;
    private float _heavyAttackRange; // Wanted to increase the range of heavy attack

    private float _colliderRadius;

    private Animator _animator;

    [SerializeField] private List<GameObject> _enemiesCollidedList;

    [SerializeField] private GameObject _closestEnemy;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        _colliderRadius = GetComponent<SphereCollider>().radius;

        _attackRange = _colliderRadius;

        _enemiesCollidedList = new List<GameObject>();

        _closestEnemy = null;
    }

    private void Update()
    {
        AttackInputHandler();

        GetClosestEnemyInRange();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") || other.isTrigger) return;

        _enemiesCollidedList.Add(other.gameObject);
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.isTrigger) return;

        _enemiesCollidedList.Remove(other.gameObject);
        _closestEnemy = null;
    }

    private void AttackInputHandler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("LightAttack");
        }
        if (Input.GetMouseButtonDown(1))
        {
            //usie heavy attack range
            _animator.SetTrigger("HeavyAttack");
        }
    }

    private void GetClosestEnemyInRange()
    {
        float closestEnemyDistance = Vector3.positiveInfinity.magnitude;

        foreach (GameObject enemy in _enemiesCollidedList)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < closestEnemyDistance)
            {
                closestEnemyDistance = distance;
                _closestEnemy = enemy;
            }
        }

        if (_closestEnemy == null) return;
        //Debug.Log(closestEnemyDistance);

        _closestEnemy.GetComponent<Health>().onDeath += OnEnemyDeathHandler;
    }

    //Triggers in animation
    private void AttackHitEvent()
    {
        if (_closestEnemy is null) return;
        if (Vector3.Distance(transform.position, _closestEnemy.transform.position) < _attackRange)
        {
            Health health = _closestEnemy.GetComponent<Health>();
            if (health is null || !health.isAlive) return;
            health.TakeDamage(_damage);
        }
    }
    //Triggers at the beginning of animation
    private void LookAtEnemy()
    {
        if (_closestEnemy == null) return;

        transform.LookAt(_closestEnemy.transform);
    }

    private void OnEnemyDeathHandler(GameObject enemy)
    {
        _enemiesCollidedList.Remove(enemy);
    }
}