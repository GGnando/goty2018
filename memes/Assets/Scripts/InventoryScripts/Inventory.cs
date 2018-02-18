using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    //This line and awake ensures 1 inventory at time and shares with all instances of class. Always able to access this inventory easy
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of inventory.");
            return;
        }

        instance = this;
    }

    //Used for event handeling and helping with UI of inventory
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    //Creates list to hold items
    public List<Item> items = new List<Item>();

    //Adds item to list
    public void Add(Item item)
    {
        items.Add(item);

        if (onItemChangedCallback != null)
        {
            //Triggering event to update UI
            onItemChangedCallback.Invoke();
        }

    }

    //Removes item from list
    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            //Triggering event to update UI
            onItemChangedCallback.Invoke();
        }
    }
}
