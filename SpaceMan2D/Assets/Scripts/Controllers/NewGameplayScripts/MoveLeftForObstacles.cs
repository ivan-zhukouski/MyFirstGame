using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftForObstacles : MonoBehaviour
{
    private float speed = 5f;
    Vector3 direction;
    private Rigidbody2D obstRB;
    
    void Awake()
    {
        obstRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        direction = Vector3.left;
        obstRB.velocity = direction * speed;
        Destroy(gameObject, 15f);
    }
}
