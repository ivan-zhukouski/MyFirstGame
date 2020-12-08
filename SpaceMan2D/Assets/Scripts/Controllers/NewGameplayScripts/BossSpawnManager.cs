using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnManager : MonoBehaviour
{
    public static bool isBoss = false;
    public static bool bossHere = false;
    public GameObject boss;
    public GameObject distanceBar;

    Vector2 bossPosition;
    Vector2 healthBarPosition;
    void Awake()
    {
        bossPosition = new Vector2(-22f, 0);
        healthBarPosition = new Vector2(0f, -39f);
        isBoss = false;
        bossHere = false;
    }

    void Update()
    {
        if(GameplayController.meters == 900)
        {
            isBoss = true;
        }
        if(GameplayController.meters == 1000 && !bossHere)
        {
            bossHere = true;
            
            BossSpawn();
        }
        BossHealthBar();

    }
    void BossSpawn()
    {
        Instantiate(boss, bossPosition, boss.transform.rotation);
    }

    void BossHealthBar()
    {
        if(bossHere)
        {
            distanceBar.gameObject.SetActive(false);
        }
    }
}
