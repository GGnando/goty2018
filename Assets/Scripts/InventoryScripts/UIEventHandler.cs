using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour {

    //Handles items and anything player does with item, this creates a type of event
    public delegate void ItemEventHandler(Item item);

    //Actual event for when item added to inventory
    public static event ItemEventHandler OnItemAddedToInventory;
    
    //This allows inventory UI to know information of item, can display item stats etc.
	public static void ItemAddedToInventory(Item item)
    {
        if(item.name != "TESTITEM")
        {
            OnItemAddedToInventory(item);
        }
        else
        {
            Debug.Log("We are testing adding items to inventory");
        }
    }

}