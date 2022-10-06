using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberEnemyController : EnemyController
{
    public int damage;
    public float explosionRadius;
    public float explodeDelay = 3f;
    public GameObject explosionVFX;


    public override void Attack()
    {
        isAttacking = true;
        Invoke("Explode", explodeDelay);
    }

    public void Explode()
    {
        Instantiate(explosionVFX, transform.position, Quaternion.identity);

        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider col in cols)
        {
            PlayerHealthManager pc = col.GetComponent<PlayerHealthManager>();
            if (pc != null)
            {
                pc.TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }
}
