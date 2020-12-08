using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBulletLeft : MonoBehaviour
{
    private float speed = 30f;
    Vector2 direction;
    private Rigidbody2D bulletRB;
   
    void Awake()
    {
        bulletRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        direction = Vector2.left;
        bulletRB.velocity = direction * speed;
        Destroy(gameObject, 1.2f);
    }
}
