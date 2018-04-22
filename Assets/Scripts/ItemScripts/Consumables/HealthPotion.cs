using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is an example of creating a script for a consumable
public class HealthPotion : MonoBehaviour, IConsumables
{
    GameObject player;

    //2 different possibilities for consuming item. One that just does something, and one that effects character's stats
    //This allows each item to have a certain consume function
    public void consume()
    {
        //Increase health of player by 40
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Health>().Heal(40);
    }

    public void consume(CharacterStat stats)
    {
    }
}
