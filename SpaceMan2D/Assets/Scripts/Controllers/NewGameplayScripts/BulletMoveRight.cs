using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveRight : MonoBehaviour
{
    private float speed = 25f;
    
    public Rigidbody2D bulletRB;
   
    void Awake()
    {
        Destroy(gameObject, 1.7f);
    }

    private void FixedUpdate()
    {
        bulletRB.velocity = transform.right * speed;
    }
}
