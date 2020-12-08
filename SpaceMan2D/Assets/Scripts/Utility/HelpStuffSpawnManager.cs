using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpStuffSpawnManager : MonoBehaviour
{
    public GameObject[] helpStaffPositions;
    public GameObject[] helpStuffPrefabs;
    public GameObject superThreeGun;
    private PlayerDeath playerDeath;
    private Vector3 offset; //spawn distance

    void Start()
    {
        playerDeath = GameObject.Find("Player").GetComponent<PlayerDeath>();
        InvokeRepeating("SpawnHelpStuff", 15f, 7f); // spawn time for helpstuff (every 7 sec)
        InvokeRepeating("SpawnSuperThreeGun", 30f, 60f);
    }

    void SpawnHelpStuff()
    {
        if(!playerDeath.isGameOver && !BossSpawnManager.isBoss)
        {
            int randomIndex = Random.Range(0, helpStaffPositions.Length);
            int randomObstIndex = Random.Range(0, helpStuffPrefabs.Length);
            GameObject stuff = Instantiate(helpStuffPrefabs[randomObstIndex], transform);
            stuff.transform.position = helpStaffPositions[randomIndex].transform.position + RandomOffset(); //spawn position
        }
    }

    void SpawnSuperThreeGun()
    {
        if (!playerDeath.isGameOver && !BossSpawnManager.isBoss)
        {
            GameObject gun = Instantiate(superThreeGun, transform);
            gun.transform.position = superThreeGun.transform.position + RandomOffset(); //spawn position
        }
    }

    Vector3 RandomOffset()// random position for helpstuff
    {
        float xPos = Random.Range(-10f, 10f);
        float yPos = Random.Range(-10f, 10f);
        offset = new Vector3(xPos, yPos);
        return offset;
    }
}
