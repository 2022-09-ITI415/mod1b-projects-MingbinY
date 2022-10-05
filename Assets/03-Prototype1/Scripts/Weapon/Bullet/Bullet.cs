using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
