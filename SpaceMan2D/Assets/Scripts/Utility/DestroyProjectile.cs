using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyProjectile : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public GameObject coin;
    public static float damage = 5f;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            
            explosionParticle.Play();
           
            Instantiate(coin, transform.position, coin.gameObject.transform.rotation);
            Destroy(other.gameObject);
           
        }

        if(other.gameObject.CompareTag("BigObstacle"))
        {
            Instantiate(coin, transform.position, coin.gameObject.transform.rotation);
            explosionParticle.Play();
        }

        if(other.gameObject.CompareTag("Boss"))
        {
            explosionParticle.Play();
        }

        Destroy(gameObject, 0.1f); //time for the particle system of explosion
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Oxygen") || other.gameObject.CompareTag("ProjectilesBox") || other.gameObject.CompareTag("SuperThreeGun"))
        {
             explosionParticle.Play();
             Destroy(other.gameObject);
             Destroy(gameObject, 0.1f);
        }
        if(other.gameObject.CompareTag("BulletsDestroyer"))
        {
            Destroy(gameObject);
        }
    }
}
