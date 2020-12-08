using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
   public GameObject[] bulletPrefab;
   public int currentBullet;
   public int maxBullet = 100;
   public ProjectileBar projectileBar;
   public Transform bulletStart;
   public ParticleSystem explosionParticle;
   private PlayerDeath playerDeath;
   int decrementBullet = 1;
   float attackSpeed = 0;
   bool isBullets;
   bool isGetBullets;
    float attackSpeedValue = 0.4f;
   
    // Start is called before the first frame update
    void Awake()
    {
        isBullets = true;
        isGetBullets = false;
        currentBullet = maxBullet;
        projectileBar.SetMaxProjectiles(maxBullet);
        playerDeath = GameObject.Find("Player").GetComponent<PlayerDeath>();
        attackSpeed = Time.time;
    }

    void Update()
    {
        if(isGetBullets)
        {
            isGetBullets = false;
            currentBullet += 30;
            projectileBar.SetProjectile(currentBullet);
        }
        if(currentBullet > maxBullet)
        {
            currentBullet = 100;
        }
    }
    void FixedUpdate()
    {
        if(Time.time > attackSpeed)
        {
            Fire();
            attackSpeed += attackSpeedValue;
        }
        if(currentBullet == 0)
        {
            isBullets = false;
        }
    }
    void Fire()
    {
     if(!playerDeath.isGameOver && PlayerFireManager.fire && isBullets)
       {
           explosionParticle.Play();
           currentBullet -= decrementBullet;
           projectileBar.SetProjectile(currentBullet);
            if(ChangeWeapon.isSuperTheeGun == true)
            {
                GameObject superThreeGun = Instantiate(bulletPrefab[1], bulletStart.position, bulletStart.rotation) as GameObject;
                Destroy(superThreeGun, 1.8f);
                attackSpeedValue = 0.6f;
            } else
            {
                Instantiate(bulletPrefab[0], bulletStart.position, bulletStart.rotation, transform);
                attackSpeedValue = 0.4f;
            }
       }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("ProjectilesBox"))
        {
            isBullets = true;
            isGetBullets = true;
            Destroy(other.gameObject);
        }
    }
}
