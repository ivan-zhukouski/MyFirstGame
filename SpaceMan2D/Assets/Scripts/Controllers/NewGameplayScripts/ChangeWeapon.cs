using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    public static bool isSuperTheeGun;
    private void Awake()
    {
        isSuperTheeGun = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SuperThreeGun"))
        {
            isSuperTheeGun = true;
            Destroy(other.gameObject);
        }

    }
}
