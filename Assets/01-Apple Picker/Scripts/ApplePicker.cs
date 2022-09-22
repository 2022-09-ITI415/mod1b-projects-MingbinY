using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net;
using UnityEngine.SceneManagement;
using System.Linq;

public class ApplePicker : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text scoreText;
    public TMP_Text healthText;
    public TMP_Text highScoreText;
    public GameObject gameOverPanel;
    public ScoreManager scoreManager;

    public int highScore;
    public int score;
    public int currentHealth;
    public int maxHealth;

    public GameObject basketPrefab;
    GameObject currentBasket;
    [SerializeField]List<GameObject> basketList;
    public int numBaskets = 3;
    public float basketBottomY = -14;
    public float basketSpacingY = 2f;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        highScore = scoreManager.highScore;
        highScoreText.text = highScore.ToString();
        maxHealth = numBaskets;
        currentHealth = maxHealth;

        //Instantiate baskets
        Vector3 pos = Vector3.zero;
        pos.y = basketBottomY;
        for (int i = 0; i < numBaskets; i++)
        {
            pos.y += basketSpacingY;
            GameObject newBasket = Instantiate(basketPrefab, pos, Quaternion.identity);
            basketList.Add(newBasket);
        }
        healthText.text = currentHealth.ToString();
    }

    private void Update()
    {

    }

    public void OnAppleDestroyed()
    {
        GameObject topBasket = basketList[-1];
        Destroy(topBasket);
        basketList.RemoveAt(-1);
        currentHealth--;
        healthText.text = currentHealth.ToString();
        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    public void OnScoreIncrease(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score.ToString();
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        Destroy(FindObjectOfType<AppleTree>().gameObject);
        Apple[] apples = FindObjectsOfType<Apple>();
        foreach (Apple apple in apples)
        {
            Destroy(apple);
        }
        if (score > highScore)
        {
            scoreManager.highScore = score;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
