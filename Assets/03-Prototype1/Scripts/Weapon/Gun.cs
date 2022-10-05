using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int bulletPerMag = 12;
    [SerializeField] int bulletInMag;
    public float reloadTime = 3f;
    public float reloadTimer;
    public bool canShoot = true;

    public Transform muzzle;
    public Bullet bullet;
    public float msBetweenShots = 100;
    public float muzzleVelocity = 40;

    public int damage = 20;

    float nextShotTime;

    private void Start()
    {
        bulletInMag = bulletPerMag;
    }

    public virtual void Update()
    {
        if (bulletInMag == 0)
        {
            canShoot = false;
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        bulletInMag = bulletPerMag;
        canShoot=true;
    }

    public virtual void Shoot()
    {
        if (Time.time > nextShotTime && canShoot)
        {
            bulletInMag--;
            nextShotTime = Time.time + msBetweenShots / 1000;
            Bullet newProjectile = Instantiate(bullet, muzzle.transform.position, transform.rotation) as Bullet;
            newProjectile.SetDamage(damage);
            newProjectile.SetSpeed(muzzleVelocity);
        }

    }

}
