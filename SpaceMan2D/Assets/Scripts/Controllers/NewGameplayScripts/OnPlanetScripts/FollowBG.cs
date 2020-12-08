using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBG : MonoBehaviour
{
    public GameObject camera;
    private Vector3 offset = new Vector3(0.0f, 0.0f, 10f);

    void Update()
    {
        transform.position = camera.transform.position + offset;
    }
}
