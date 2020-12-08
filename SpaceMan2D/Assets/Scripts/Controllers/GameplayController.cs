using System.Collections;
using UnityEngine;
using TMPro;

public class GameplayController : MonoBehaviour
{
    
    
    private PlayerDeath playerDeath;
    
    public static int meters;

    void Awake()
    {
        EventManager.StartListening(GameEvent.SCORE_UPDATED, UpdateScore);
        InvokeRepeating("MetersScore", 0.0f, 0.1f);
        playerDeath = GameObject.Find("Player").GetComponent<PlayerDeath>();
        meters = 0;
    }

    void Update() 
    {
       //distanceText.text = meters + "m";
    }

    private void UpdateScore(Hashtable eventArgs) //score in the game
    {
        //scoreText.text = "Score: " + eventArgs["score"];
    }

    void MetersScore()
    {
        if(!playerDeath.isGameOver && !BossSpawnManager.bossHere)
        {
            meters += 1;
        }
    }
}
