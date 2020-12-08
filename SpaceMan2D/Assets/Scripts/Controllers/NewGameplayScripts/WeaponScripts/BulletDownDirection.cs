using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDownDirection : MonoBehaviour
{
    float speed = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.7f);
    }
    Vector2 VectorFromAngle(float cos, float sin)
    {
        return new Vector2(Mathf.Cos(cos), Mathf.Sin(sin))* 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(VectorFromAngle(-314.5f, -314.5f)); //-314.5
    }
}
