using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Basket : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score = 0;

    private void Start()
    {
        scoreText = FindObjectOfType<ApplePicker>().scoreText;
        score = 0;
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = transform.position;
        pos.x = mousePos3D.x;
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Apple")
        {
            score++;
            scoreText.text = score.ToString();
            Destroy(collidedWith);
        }
    }
}
