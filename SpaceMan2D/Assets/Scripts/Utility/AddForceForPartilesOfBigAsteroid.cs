using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceForPartilesOfBigAsteroid : MonoBehaviour
{
    private Rigidbody2D rb;
    float directionX;
    float directionY;
    float torque;
    float speed = 10f;
    public static ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        directionX = Random.Range(-5, 5);
        directionY = Random.Range(-8, 8);
        torque = Random.Range(-15, 15);

        rb.AddForce(new Vector2(directionX, directionY) * speed, ForceMode2D.Impulse);
        rb.AddTorque(torque, ForceMode2D.Force);
        Destroy(gameObject, 60f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
