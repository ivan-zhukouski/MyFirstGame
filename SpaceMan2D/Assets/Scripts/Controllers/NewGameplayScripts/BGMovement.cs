using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMovement : MonoBehaviour
{
   
    public float speed = 20f;
    private float lowerBound = -60f;
    private PlayerDeath playerDeath;

    void Awake()
    {
        playerDeath = GameObject.Find("Player").GetComponent<PlayerDeath>();
    }

    void Update()
    {
        
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }
        if(BossSpawnManager.bossHere == true)
        {
            speed = 0f;
        }

    }
}
