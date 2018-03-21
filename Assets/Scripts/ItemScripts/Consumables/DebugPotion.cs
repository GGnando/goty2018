using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPotion : MonoBehaviour, IConsumables {

    public void consume()
    {
        Debug.Log("This is a test to make sure consume works.");
    }

    public void consume(CharacterStat stats)
    {
        Debug.Log("This is a test to make sure consume works with a stat change");
    }
}
