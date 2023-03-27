using UnityEngine;

public class FightSniper : Fight
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _bulletVelocity;

    [SerializeField] private Transform _bulletSpawnPoint;

    //to add: dont attack if other enemy is infront of the shot
    public override void Attack(Health health)
    {
        if (Time.time > _cooldownEnd && !GetComponent<RayCast>().IsBlocked(_playerRef))
        {
            //to add: make it stay in one place for a second before shooting
            transform.LookAt(_playerRef.transform);

            GameObject currentBullet = Instantiate(_bullet, _bulletSpawnPoint.transform.position, Quaternion.identity);


            Vector3 distance = _playerRef.transform.position - gameObject.transform.position;

            currentBullet.transform.forward = distance;

            currentBullet.GetComponent<Rigidbody>().AddForce(distance.normalized * _bulletVelocity, ForceMode.Impulse);

            _cooldownEnd = Time.time + _cooldown;
        }
    }
}