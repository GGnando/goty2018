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

<<<<<<< HEAD
    //Creates list to hold items
    public List<Item> items = new List<Item>();

=======
    //Creates list to hold items of each type
    public List<Item> items = new List<Item>();

    //List of all the types of items
    public List<Item> weapons = new List<Item>();
    public List<Item> shields = new List<Item>();
    public List<Item> armor = new List<Item>();
    public List<Item> consumables = new List<Item>();
    public List<Item> resources = new List<Item>();
    public List<Item> quests = new List<Item>();

>>>>>>> Tyler-branch
    //Getters for List of items for testing
    public List<Item> getItems()
    {
        return items;
    }

    //Adds item to list
    public void Add(Item item)
    {
        items.Add(item);

<<<<<<< HEAD
=======
        //Add specific item to item type list:
        if(item.itemType == Item.ItemType.Quest)
        {
            quests.Add(item);
        }
        if(item.itemType == Item.ItemType.Resource)
        {
            resources.Add(item);
        }
        if(item.itemType == Item.ItemType.Consumable)
        {
            consumables.Add(item);
        }
        if (item.itemType == Item.ItemType.Armor)
        {
            armor.Add(item);
        }
        if (item.itemType == Item.ItemType.Shield)
        {
            shields.Add(item);
        }
        if (item.itemType == Item.ItemType.Weapon)
        {
            weapons.Add(item);
        }

>>>>>>> Tyler-branch
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

<<<<<<< HEAD
=======
        //Remove item from its list:
        if (item.itemType == Item.ItemType.Quest)
        {
            quests.Remove(item);
        }
        if (item.itemType == Item.ItemType.Resource)
        {
            resources.Remove(item);
        }
        if (item.itemType == Item.ItemType.Consumable)
        {
            consumables.Remove(item);
        }
        if (item.itemType == Item.ItemType.Armor)
        {
            armor.Remove(item);
        }
        if (item.itemType == Item.ItemType.Shield)
        {
            shields.Remove(item);
        }
        if (item.itemType == Item.ItemType.Weapon)
        {
            weapons.Remove(item);
        }

>>>>>>> Tyler-branch
        if (onItemChangedCallback != null)
        {
            //Triggering event to update UI
            onItemChangedCallback.Invoke();
        }
    }
}
