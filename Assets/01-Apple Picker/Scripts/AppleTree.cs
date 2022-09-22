using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]

    // Prefab for instantiating apples

    public GameObject applePrefab;

    // Speed at which the AppleTree moves

    public float defaultSpeed = 1f;
    public float speedMultiply = 1f;
    public float speedCap = 1;

    // Distance where AppleTree turns around

    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change di

    public float chanceToChangeDirection;

    // Rate at which Apples will be instantiate

    public float secondsBetweenAppleDrop;


    void Start()
    {
        speedCap = 1;
        // Dropping apples every second
        Invoke("DropApple", 2f);

    }

    void Update()
    {

        // Basic Movement
        Vector3 pos = transform.position;

        pos.x += defaultSpeed * Time.deltaTime;

        transform.position = pos;

        // Changing Direction
        if (pos.x < -leftAndRightEdge)
        {

            defaultSpeed = Mathf.Abs(defaultSpeed); // Move ri
        }
        else if (pos.x > leftAndRightEdge)
        {

            defaultSpeed = -Mathf.Abs(defaultSpeed); // Move l
        }
    }

    void FixedUpdate()
    {

        // Changing Direction Randomly is now t

        if (Random.value < chanceToChangeDirection)
            defaultSpeed *= -1; // Change direction
    }

    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab, transform.position, Quaternion.identity);
        Invoke("DropApple", GetNewBetweenDropTime());
    }

    float GetNewBetweenDropTime()
    {
        float newTime = Random.value * secondsBetweenAppleDrop;
        return newTime;
    }

    public void UpdateSpeedMultiply()
    {
        if (speedCap >= 2)
        {
            speedCap = Random.Range(speedCap - 1, speedCap);
        }
        else
        {
            speedCap = Random.Range(1, speedCap);
        }
        
        defaultSpeed = speedCap;
    }
}
