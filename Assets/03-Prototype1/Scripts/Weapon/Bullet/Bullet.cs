using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public int damage = 10;

    private void Start()
    {
        GetComponent<Collider>().isTrigger = true;
        Destroy(gameObject, 10f);
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        BasicHealthManager hm = other.GetComponent<BasicHealthManager>();
        if (hm)
        {
            hm.TakeDamage(damage);
        }


        Destroy(gameObject);
    }
}
