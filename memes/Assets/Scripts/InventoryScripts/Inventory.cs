using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    //This line and awake ensures 1 inventory at time and shares with all instances of class. Always able to access this inventory easy
    public static Inventory instance;

    //Allows access to consuming items
    public ConsumablesController consumableController;

    //Reference to panel that displays item info
    public InventoryUIDetails inventoryDetailsPanel;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of inventory.");
            return;
        }

        instance = this;
    }

    //Testing inventory system here:
    private void Start()
    {
        Item debugPotion = new Item("DebugPotion", Resources.Load<Sprite>("InventoryUI/icons/png/64px/Inventory_Potion"), "Testing potion", Item.ItemType.Consumable, true, true, 5, 0.5, 1, 1, "Drink", true);
        Item healthPotion = new Item("Health Potion", Resources.Load<Sprite>("InventoryUI/icons/png/64px/Weapons_Sword"), "This is a health potion. What do you think it does.", Item.ItemType.Consumable, true, true, 10, 0.3, 1, 1, "Drink", true);
        Add(debugPotion);
        Add(healthPotion);
        Debug.Log("Added some potions (Delete this later)");

    }


    //Used for event handeling and helping with UI of inventory
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    //Creates list to hold items of each type
    public List<Item> items = new List<Item>();

    //List of all the types of items
    public List<Item> weapons = new List<Item>();
    public List<Item> shields = new List<Item>();
    public List<Item> armor = new List<Item>();
    public List<Item> consumables = new List<Item>();
    public List<Item> resources = new List<Item>();
    public List<Item> quests = new List<Item>();

    //Getters for List of items for testing
    public List<Item> getItems()
    {
        return items;
    }

    //Adds item to list
    public void Add(Item item)
    {
        items.Add(item);

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

        //Adds to event and calls everything subscribed to event, so all inventory gets updated and displayed
        UIEventHandler.ItemAddedToInventory(item);

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

        if (onItemChangedCallback != null)
        {
            //Triggering event to update UI
            onItemChangedCallback.Invoke();
        }
    }

    //Method for displaying item info
    public void setItemDetails(Item item, Button button)
    {
        inventoryDetailsPanel.setItem(item, button);
    }

    //Equiping item from inventory code:
    //Add equip weapons later

    //Consumables:
    public void ConsumeItem(Item consumedItem)
    {
        consumableController.consumeItem(consumedItem);
    }
}
