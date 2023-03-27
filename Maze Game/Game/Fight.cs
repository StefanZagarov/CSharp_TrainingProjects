using System.Collections.Generic;
using UnityEngine;

public abstract class Fight : MonoBehaviour
{
    [SerializeField] protected float _damage = 0;

    [SerializeField] protected float _cooldown = 2f;
    protected float _cooldownEnd;

    protected GameObject _playerRef;

    private void Awake()
    {
        _cooldownEnd = _cooldown;

        _playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay(Collider other)
    {
        Health health = other.GetComponent<Health>(); //Gets Health component if the collided object has one, else it assigns null

        if (health is null || !health.isAlive) return; //If the collided object doesnt have Health component GetComponent returns null        
        if (gameObject.tag == other.tag) return; //If the Health component is of an object with the same tag then it doesnt attack it
        if (other.isTrigger) return; //Makes it so if two triggers touch each other the script wont be initiated, it will be only if the trigger range touches a box collider

        Attack(health);
    }

    public abstract void Attack(Health health);
}
