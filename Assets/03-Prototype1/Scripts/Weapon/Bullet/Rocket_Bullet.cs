using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_Bullet : Bullet
{
    public float explosionRadius = 5f;
    public override void OnTriggerEnter(Collider other)
    {

        //Explosion VFX
        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider col in cols)
        {
            BasicHealthManager hm = col.GetComponent<BasicHealthManager>();
            if (hm)
            {
                hm.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }

}
