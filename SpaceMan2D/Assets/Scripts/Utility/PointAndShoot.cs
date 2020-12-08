using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    private Rigidbody2D player;
    public GameObject bulletPrefab;
    public GameObject bulletStart;
    private float impulsForce = 100f; //for player
    private float bulletSpeed = 20f;
    private Vector3 target;
    public ParticleSystem shootParticle;
    public ProjectileBar projectileBar;
    public int maxProjectile = 100;
    public int currentProjectile;
    public bool isProjectile = true;// if you have projectiles, you can shoot
    private Vector3 difference;
    private float rotationZ;
    public float maxPlayerSpeed = 7f;
    public GameObject projectilePrefab;

    private PlayerDeath playerDeath;

    float rotationSpeed = 0.2f;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        playerDeath = GameObject.Find("Player").GetComponent<PlayerDeath>();
        currentProjectile = maxProjectile;
        projectileBar.SetMaxProjectiles(maxProjectile);
    }

    void FixedUpdate()
    {
        /*target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                                 Input.mousePosition.y, 
                                                                                 Input.mousePosition.z));*/
        Debug.Log(rotationZ);
        if(Input.GetMouseButtonDown(0))
        {
            target = transform.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(target);
        }
        if(!playerDeath.isGameOver)
        {
            difference = (target - player.transform.position).normalized;
            rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            player.transform.rotation = Quaternion.Euler(0.0f,0.0f, rotationZ);
        }
     

        if(Input.GetMouseButtonDown(0) && isProjectile && !playerDeath.isGameOver) // check are there any prijectiles
        {
            shootParticle.Play();
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            FireBullet(direction, rotationZ);
            ProjectileDecrement(1);
        }

        GetProjectile();
        player.velocity = Vector3.ClampMagnitude(player.velocity, maxPlayerSpeed);// add max speed for player
    }

    void FireBullet( Vector2 direction, float rotationZ)
    {
        GameObject bullet = Instantiate(bulletPrefab, projectilePrefab.transform);
        Destroy(bullet, 1f);
        bullet.transform.position = bulletStart.transform.position;
        bullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        player.AddForce(-direction * impulsForce, ForceMode2D.Impulse);
    }

    void ProjectileDecrement(int oneShoot)
    {
        currentProjectile -= oneShoot;
        
        if(currentProjectile <= 0 )
        {
            isProjectile = false;
        }
       
        projectileBar.SetProjectile(currentProjectile);
    }

    void GetProjectile()
    {
         if(playerDeath.isGetProjectiles)
        {
            currentProjectile += 20;
            playerDeath.isGetProjectiles = false;
            projectileBar.SetProjectile(currentProjectile);
        }
    }
}
