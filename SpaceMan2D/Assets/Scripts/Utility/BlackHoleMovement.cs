using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlackHoleMovement : MonoBehaviour
{
    public TextMeshProUGUI deirectionToHoleText;
    float timeCounter = 0;
    float timeCounterTwo = 0;
    float speed = 0.1f;
    Vector3 difference;
    public GameObject parentForHole;
    public GameObject player;
    public GameObject[] randomOrbit;
    float distanceForOrbitX;
    float distanceForOrbitY;
    int index;
    float distanceForHole;

    void Awake()
    {
        distanceForOrbitX = Random.Range(-100, 100);
        distanceForOrbitY = Random.Range(-100, 100);
        index = Random.Range(0, randomOrbit.Length);
    }

    void FixedUpdate()
    {
        OrbitAround();
        DirectionForPlayer();
    }
    void OrbitAround()
    {
        timeCounter += Time.deltaTime * speed;
        timeCounterTwo +=Time.deltaTime * 0.01f;

        float x = Mathf.Cos(timeCounter) * 15;
        float y = Mathf.Sin(timeCounter) * 4;
        float z = 0;
        Vector3 offset = new Vector3(x,y,z);

        if(index == 0 || index == 3)
        {
            distanceForHole = 100f;
        }
        if(index == 1 || index == 2)
        {
            distanceForHole = -100;
        }
        float parentX = Mathf.Cos(timeCounterTwo)* distanceForHole;
        float parentY = Mathf.Sin(timeCounterTwo)* distanceForHole;
        float parentZ = 0;
        Vector3 orbitOffset = new Vector3 (parentX, parentY, parentZ);

        parentForHole.transform.position = randomOrbit[index].transform.position + orbitOffset;
        transform.position = parentForHole.transform.position + offset;
    }
    void DirectionForPlayer()
    {
        difference = transform.position - player.transform.position;
        int diffX = (int)difference.x;
        int diffY = (int)difference.y;
        deirectionToHoleText.text = "Hole In:" + diffX + ", " + diffY;
    }
}
