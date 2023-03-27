using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 0f;
    private float _currentHealth = 0f;
    private HealthBar _healthBar;
    public bool isAlive;

    private Animator _animator;
    public event Action<GameObject> onDeath;

    private void Awake()
    {
        isAlive = true;
        _animator = GetComponent<Animator>();
        _currentHealth = _maxHealth;
        _healthBar = GetComponentInChildren<HealthBar>(); //Gets component from a children right below this object
    }

    private void Start()
    {
        _healthBar.SetMaxHealth(_maxHealth);
        _healthBar.SetCurrentHealth(_currentHealth);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        _healthBar.SetCurrentHealth(_currentHealth);

        if (_currentHealth <= 0)
        {
            onDeath?.Invoke(gameObject); //the event is called by subscribed classes everytime an object is about to be destroyed, ? means that its called only if someone is subscribed to the event
            _animator.SetTrigger("isDead");
            isAlive = false;
            GetComponent<BoxCollider>().enabled = false;
            //disable health bar
        }
    }

    //Methods activated in Animation Events
    private void DestroyGameObject()
    {
        Destroy(gameObject, 5f);
    }

    private void DisableCharacterOnDeath()
    {
        GetComponent<PlayerMovement>().enabled = false;
    }       
}