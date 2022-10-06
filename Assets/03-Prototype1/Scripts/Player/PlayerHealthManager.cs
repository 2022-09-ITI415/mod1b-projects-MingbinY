using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerHealthManager : BasicHealthManager
{
    public Image healthBar;
    public GameObject gameOverUI;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
    }

    public override void Death()
    {
        base.Death();
        GetComponent<PlayerController>().GetComponent<PlayerInput>().enabled = false;
        gameOverUI.SetActive(true);
    }
}
