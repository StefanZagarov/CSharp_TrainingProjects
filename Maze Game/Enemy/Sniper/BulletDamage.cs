using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _lifetime = 10f;

    private void Start()
    {
        Destroy(gameObject, _lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        TryTakeDamage(collision);
        Destroy(gameObject);
    }

    private void TryTakeDamage(Collision collision)
    {
        if (collision.gameObject.tag == ("Enemies")) return;

        Health health = collision.gameObject.GetComponent<Health>();

        if (health is null) return;
        health.TakeDamage(_damage);
    }
}