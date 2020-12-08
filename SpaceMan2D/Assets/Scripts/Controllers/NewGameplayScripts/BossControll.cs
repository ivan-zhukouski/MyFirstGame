using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControll : MonoBehaviour
{
    Rigidbody2D bossRB;
    float timeCounter = 0;
    float timeCounterTwo = 0;
    float speed = 0.7f;
    public float maxHealth = 100f;
    public float currentHealth;
    public static bool isBossDead = false;
    bool isTeleport = false;

    public GameObject bulletPrefab;
    public GameObject bulletStart;
    private PlayerDeath playerDeath;
    public BossHealthBar healthBar;
    public ParticleSystem explosionParticle;
    public GameObject teleportPrefab;
    Vector2 teleportPos;

    void Awake()
    {
        bossRB = GetComponent<Rigidbody2D>();
        playerDeath = GameObject.Find("Player").GetComponent<PlayerDeath>();

        InvokeRepeating("BossFire", 1f, 1f);

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        teleportPos = new Vector2(-19f, 0);
        isTeleport = false;
        isBossDead = false;
    }

    void FixedUpdate()
    {
        BossMovement();

        if(currentHealth <=0)
        {
            isBossDead = true;
            Destroy(gameObject);
        }
        if(isBossDead && !isTeleport)
        {
            isTeleport = true;
            Instantiate(teleportPrefab, teleportPos, teleportPrefab.transform.rotation);
        }
    }
    void BossMovement()
    {
        timeCounter += Time.deltaTime * speed;

        float x = Mathf.Cos(timeCounter) * 1;
        float y = Mathf.Sin(timeCounter) * 7;
        float z = 0;
        Vector3 offset = new Vector3(x,y,z);
        transform.position = new Vector3(-22, 0, 0) + offset;
    }
    
    void BossFire()
    {
         if(!playerDeath.isGameOver) 
       {
           explosionParticle.Play();
           Instantiate(bulletPrefab, bulletStart.transform.position, bulletPrefab.transform.rotation);
       }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Projectile"))
        {
            currentHealth -= DestroyProjectile.damage;
            healthBar.SetHealth(currentHealth);
        }
    } 
}
