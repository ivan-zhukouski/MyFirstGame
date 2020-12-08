using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovementForObst : MonoBehaviour
{
    float timeCounter = 0;
    float speed = 0.7f;
    public static Vector3 offset;
    private float speedM = 5f;
    Vector3 direction;
    private Rigidbody2D obstRB;
    float waveDirection;
  
    void Awake()
    {
        obstRB = GetComponent<Rigidbody2D>();
        waveDirection = Random.Range(-1f, 1f);
    }
   
    void FixedUpdate()
    {
        BossMovement();
        direction = Vector3.left + WaveMovementForObst.offset;
        obstRB.velocity = direction * speedM;
        Destroy(gameObject, 15f);
    }

    void BossMovement()
    {
        timeCounter += Time.deltaTime * speed;

        float x = Mathf.Cos(timeCounter) * 0.1f;
        float y = Mathf.Sin(timeCounter) * waveDirection;
        float z = 0;
        offset = new Vector3(x, y, z);
    }
}
