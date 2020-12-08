using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    
    public static float score = 0;

    void Awake() {
        if (gameManager == null)
        {
            gameManager = gameObject.GetComponent<GameManager>();
        }
        DontDestroyOnLoad(gameManager);
    }

    public static void IncrementScore(int value)
    {
        Hashtable hashtable = new Hashtable();

        score += value;
        hashtable.Add("score", score);

        EventManager.TriggerEvent(GameEvent.SCORE_UPDATED, hashtable);
    }
}
