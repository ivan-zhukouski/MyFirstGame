using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] bigObstacles;

    public GameObject[] spawnPosition;
    public Vector3 offset;
    private PlayerDeath playerDeath;
    
    void Awake()
    {
        playerDeath = GameObject.Find("Player").GetComponent<PlayerDeath>();
        InvokeRepeating("SpawnObstacles", 1f, 1f); //spawn obstacles every 1 sec
        InvokeRepeating("SpawnBigObstacles", 1f, 5f); //spawn obstacles every 5 sec
    }

    void SpawnObstacles()
    {
        if(!playerDeath.isGameOver && !BossSpawnManager.isBoss)
        {
            int randomPosIndex = Random.Range(0, spawnPosition.Length);
            int randomObstIndex = Random.Range(0, obstacles.Length);
            GameObject obst = Instantiate(obstacles[randomObstIndex], transform);
            obst.transform.position = spawnPosition[randomPosIndex].transform.position + RandomOffset();
            Destroy(obst, 60f);
        }
    }
    void SpawnBigObstacles()
    {
          if(!playerDeath.isGameOver && !BossSpawnManager.isBoss)
        {
            int randomPosIndex = Random.Range(0, spawnPosition.Length);
            int randomObstIndex = Random.Range(0, bigObstacles.Length);
            GameObject obst = Instantiate(bigObstacles[randomObstIndex], transform);
            obst.transform.position = spawnPosition[randomPosIndex].transform.position + RandomOffset();
        }
    }
    Vector3 RandomOffset() //random position for obstacles
    {
        float xPos = Random.Range(-10f, 10f);
        float yPos = Random.Range(-10f, 10f);
        offset = new Vector3(xPos, yPos);
        return offset;
    }
}
