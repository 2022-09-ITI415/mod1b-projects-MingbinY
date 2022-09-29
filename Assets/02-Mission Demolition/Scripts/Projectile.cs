using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum ProjectileType
{
    normal,
    explosive
}
public class Projectile : MonoBehaviour
{
    public ProjectileType pType = ProjectileType.normal;

    private void OnCollisionEnter(Collision collision)
    {
        switch (pType)
        {
            case ProjectileType.normal:
                break;
            case ProjectileType.explosive:
                Explode();
                break;
        }
    }

    private void Explode()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 10f);
        foreach (Collider col in cols)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();

            if (rb)
            {
                Vector3 dir = col.transform.position - transform.position;
                rb.AddForce(dir * 10f, ForceMode.Impulse);
            }
        }
        Destroy(gameObject, 3f);
    }
}
