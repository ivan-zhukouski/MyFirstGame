using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDeath : MonoBehaviour
{
    public float maxOxygen = 100f;
    public float currentOxygen;
    public OxygenBar oxygenBar;
    public float maxHealth = 100f;
    public float currentHealth;
    public HealthBar healthBar;
    public bool isGetProjectiles;
    public bool isGameOver;
    public Button restartButton;
    public Button mainMenuButton;
    public TextMeshProUGUI gameOverText;
    private float decrementOxygen = 0.1f;
    private float currentDecrement;
    public float currentPlayerSpeed;
    private Rigidbody2D playerRB;
    
    void Awake()
    {
        currentOxygen = maxOxygen;
        oxygenBar.SetMaxOxygen(maxOxygen);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        InvokeRepeating("RunOutOfOxygen", 1f, 0.1f);
        playerRB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        currentPlayerSpeed = playerRB.velocity.magnitude;

        if(currentOxygen > maxOxygen)
        {
            currentOxygen = 100f;
        }
    }

    void RunOutOfOxygen()
    {
        if(!isGameOver)
        {
            currentOxygen -= decrementOxygen;
            oxygenBar.SetOxygen(currentOxygen);

            if(currentOxygen <= 0)
            {
                GameOver();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            if(currentPlayerSpeed >= 5f && currentPlayerSpeed <=7f)
            {
              currentHealth -= 30f;
              healthBar.SetHealth(currentHealth);
            }
            if(currentPlayerSpeed >=3f && currentPlayerSpeed <= 5f)
            {
              currentHealth -= 10f;
              healthBar.SetHealth(currentHealth);
            }
            if(currentPlayerSpeed >=1f && currentPlayerSpeed <= 3f)
            {
              currentHealth -= 5f;
              healthBar.SetHealth(currentHealth);
            }
            if(currentPlayerSpeed >=0f && currentPlayerSpeed <= 1f)
            {
              currentHealth -= 2f;
              healthBar.SetHealth(currentHealth);
            }

            decrementOxygen = 0.2f;
        }

        if(other.gameObject.CompareTag("BossProjectile"))
        {
            currentHealth -= BossProjectile.damage;
            healthBar.SetHealth(currentHealth);
        }
         if(currentHealth <= 0 )
            {
                GameOver();
            }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Oxygen"))
        {
            decrementOxygen = 0.1f;
            currentOxygen += 20f;
            Destroy(other.gameObject);
        }
        
    }
    void GameOver()
    {
        isGameOver = true;
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
    }
}
