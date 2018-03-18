using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPotion : MonoBehaviour, IConsumables {

    public void consume()
    {
        Debug.Log("This is a test to make sure consume works.");
    }

    //Eventually implement one to effect stats
}
