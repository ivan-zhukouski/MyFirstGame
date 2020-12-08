using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionForObstacle : MonoBehaviour
{
    public GameObject particleAfterExplosion;
    public GameObject positionOne;
    public GameObject positionTwo;
    private bool isExplosed = false;
   private void OnCollisionEnter2D(Collision2D other)
   {
       if(other.gameObject.CompareTag("Projectile"))
       {
           for(int i = 0; i < 4; i++)
           {
              Instantiate(particleAfterExplosion, positionOne.transform.position, particleAfterExplosion.transform.rotation);
           }
           Debug.Log("explosed");
       }
   }
}
