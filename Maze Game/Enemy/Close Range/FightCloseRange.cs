using UnityEngine;

public class FightCloseRange : Fight
{
    public override void Attack(Health health)
    {
        if (Time.time > _cooldownEnd && !GetComponent<RayCast>().IsBlocked(_playerRef))
        {            
            health.TakeDamage(_damage);
            _cooldownEnd = Time.time + _cooldown;
        }
    }
}