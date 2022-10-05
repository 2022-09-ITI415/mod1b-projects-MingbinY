using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform muzzle;
    public Bullet bullet;
    public float msBetweenShots = 100;
    public float muzzleVelocity = 40;

    float nextShotTime;

    public virtual void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            Bullet newProjectile = Instantiate(bullet, muzzle.transform.position, transform.rotation) as Bullet;
            newProjectile.SetSpeed(muzzleVelocity);
        }

    }

}
