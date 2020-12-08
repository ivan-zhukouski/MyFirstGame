using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBigObstacles : MonoBehaviour
{
    private Rigidbody2D bigObstRB;

    private Vector2 direction;

    void Awake()
    {
        bigObstRB = GetComponent<Rigidbody2D>();
    }

}
