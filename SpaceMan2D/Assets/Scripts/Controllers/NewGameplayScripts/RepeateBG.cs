using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeateBG : MonoBehaviour
{
  
    private Vector3 startPos;
    private float repeatWidth;

    void Awake()
    {
        repeatWidth = GetComponent<BoxCollider2D>().size.x / 2;
        transform.position = startPos;
    }
    
    void Update()
    {
        if(transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }

    }
}
