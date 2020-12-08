using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBigAsteroid : MonoBehaviour
{
    private int scorePoint = 1;
    public GameObject ast_0, ast_1, ast_2, ast_3, ast_4, ast_5;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Projectile"))
        {
            GameManager.IncrementScore(scorePoint); //update score text when a projectile reached an obstacle;
            Instantiate(ast_0, transform.position, Quaternion.identity);
            Instantiate(ast_1, transform.position, Quaternion.identity);
            Instantiate(ast_2, transform.position, Quaternion.identity);
            Instantiate(ast_3, transform.position, Quaternion.identity);
            Instantiate(ast_4, transform.position, Quaternion.identity);
            Instantiate(ast_5, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
