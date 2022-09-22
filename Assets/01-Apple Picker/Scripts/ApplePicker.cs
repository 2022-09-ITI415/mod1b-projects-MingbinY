using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ApplePicker : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text scoreText;

    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14;
    public float basketSpacingY = 2f;

    private void Start()
    {
        for (int i=0; i < numBaskets; i++)
        {
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY);
            GameObject tBasketGo = Instantiate(basketPrefab, pos, Quaternion.identity);

        }
    }
}
