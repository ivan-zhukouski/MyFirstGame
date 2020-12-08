using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireManager : MonoBehaviour
{
    public static bool fire = false;
    
    public void FirePointerDown()
    {
        fire = true;
    }
    public void FirePointerUp()
    {
        fire = false;
    }
}
