using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerEnemyController : EnemyController
{
    public Gun gunnerWeapon;

    public override void Awake()
    {
        base.Awake();
        gunnerWeapon = GetComponentInChildren<Gun>();
        gunnerWeapon.b_source = BulletSource.Enemy;
    }

    public override void Attack()
    {
        base.Attack();
        gunnerWeapon.Shoot(BulletSource.Enemy);
        Invoke("ResetCooldown", attackCooldown);
    }

    public void ResetCooldown()
    {
        isAttacking = false;
    }
}
