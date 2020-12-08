using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    private GameObject player;
    private float coinSpeed =20f;
    Vector3 target;

    private Rigidbody2D rbCoin;
    
    void Awake()
    {
        rbCoin = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        target = (player.transform.position - transform.position).normalized;
        rbCoin.velocity = target * coinSpeed;
    }
}
