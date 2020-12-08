using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftForHelpStuff : MonoBehaviour
{
    public float speed = 4f;
    Vector2 direction;
    private Rigidbody2D helpStaffRB;
    
    void Awake()
    {
        helpStaffRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        direction = Vector2.left;
        helpStaffRB.velocity = direction * speed;
        Destroy(gameObject, 15f);
    }
}
