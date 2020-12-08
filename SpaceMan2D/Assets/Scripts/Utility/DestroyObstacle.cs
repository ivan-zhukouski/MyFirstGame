using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    private int scorePoint = 1;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Projectile"))
        {
            GameManager.IncrementScore(scorePoint); //update score text when a projectile reached an obstacle;
        }
    }
}
