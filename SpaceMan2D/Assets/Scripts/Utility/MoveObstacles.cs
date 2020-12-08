using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacles : MonoBehaviour
{
    private Vector2 direction; //direction for obstacles
    private Transform playerPosition;
    private float speed = 200f;
    private Rigidbody2D obstacleRb;

    void Start()
    {
        playerPosition = GameObject.Find("Player").GetComponent<Transform>();
        obstacleRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       MoveToPlayer();
    }

    void MoveToPlayer()
    {
        direction = (playerPosition.transform.position - transform.position).normalized;
        obstacleRb.velocity = direction * speed * Time.deltaTime;
    }
}
