using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{  public static PlayerController Instance //singlton
   {
       get
       {
           if(instance == null)
           {
               instance = FindObjectOfType<PlayerController>();
               if(instance == null)
               {
                   var instanceContainer = new GameObject("PlayerController");
                   instance = instanceContainer.AddComponent<PlayerController>();
               }
           }
           return instance;
       }
   }
   private static PlayerController instance;
   Rigidbody2D rb;
   float moveSpeed = 7f;

   private PlayerDeath playerDeath;
   public TextMeshProUGUI coinScore;
   public ParticleSystem explosionParticle;
   private int coins = 0;
   float positionRangeX = -18f;
   float positionRangeX_ = -52f;
   float positionRangeY= 9f;
   public static bool fire = false;
   public Joystick joystick;


    void Awake()
    {
       rb = GetComponent<Rigidbody2D>();
       playerDeath = GameObject.Find("Player").GetComponent<PlayerDeath>();
    }

    void FixedUpdate()
    {
       Movement();
       PositionRange();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            coins += 1;
            coinScore.text = "Coins: " + coins;
            Destroy(other.gameObject);
        }
    }
    void PositionRange()
    {
       if(transform.position.x >= positionRangeX)
       {
           transform.position = new Vector3(positionRangeX, transform.position.y, transform.position.z);
       }
       if(transform.position.x <= positionRangeX_)
       {
           transform.position = new Vector3(positionRangeX_, transform.position.y, transform.position.z);
       }
       if(transform.position.y >= positionRangeY)
       {
           transform.position = new Vector3(transform.position.x, positionRangeY, transform.position.z);
       }
       if(transform.position.y <= -positionRangeY)
       {
           transform.position = new Vector3(transform.position.x, -positionRangeY, transform.position.z);
       }
    }
    void Movement()
    {
       float moveH = joystick.Horizontal;
       float moveV = joystick.Vertical;

      // rb.velocity = new Vector3(moveH * moveSpeed, moveV * moveSpeed,  rb.velocity.y);
        
        if(!playerDeath.isGameOver)
        {
            rb.velocity = new Vector3(moveH * moveSpeed, moveV * moveSpeed, rb.velocity.y);
        }
    }
}
