using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour {

    //This line and awake ensures 1 inventory at time and shares with all instances of class. Always able to access this inventory easy
    public static Inventory instance;

    //Allows access to consuming items
    public ConsumablesController consumableController;
    public PlayerWeaponController playerWeaponController;

    Item currentWeapon;

    //Reference to panel that displays item info for each tab inventory
    public InventoryUIDetails ConsumablesDetailsPanel;
    public InventoryUIDetails WeaponsDetailsPanel;
    public InventoryUIDetails ArmorDetailsPanel;
    public InventoryUIDetails ShieldsDetailsPanel;
    public InventoryUIDetails ResourcesDetailsPanel;
    public InventoryUIDetails CraftablesDetailsPanel;

    //Max size of item stacl
    const int MAXSTACKSIZE = 99;

    //Reference to panel for max stack
    public Transform MaxStackPanel;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of inventory.");
            return;
        }

        instance = this;
    }

    void Start()
    {
        currentWeapon = ItemDatabase.instance.getItem("Sword_2H");
            
        //Testing inventory by adding items if not running unit tests
        if (SceneManager.GetActiveScene().name == "StartArea")
        {
            Add("Wood");
            Add("Wood");
            Add("Wood");
            
            for(int i = 0; i < 58; i++)
            {
                Add("Wood");
            }
            
            Add("DebugPotion");
            Add("DebugPotion");
            Add("DebugPotion");
            Add("Sword");
            Add("Axe");
            Add("Sword");
            Add("Iron Helmet");
            Add("Iron Shield");
            Add("Iron Sword Recipe");
        }

        consumableController = GetComponent<ConsumablesController>();
        playerWeaponController = GetComponent<PlayerWeaponController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            playerWeaponController.EquipWeapon(currentWeapon);
        }
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
    public List<Item> craftables = new List<Item>();

    //Getters for List of items for testing
    public List<Item> getItems()
    {
        return items;
    }

    //Adds item to list
    public void Add(string itemName)
    {
        //Grab instance of item here and add to items list
        Item itemAdded = ItemDatabase.instance.getItem(itemName);
        //Check if limit of 99 of 1 item is reached
        if (checkLimit(itemAdded))
        {
            Debug.Log("Cannot add more of " + itemName + ". Max stack size reached.");
            MaxStackPanel.gameObject.SetActive(true);
            return;
        }

        //QuantityCheck checks if item already in inventory for stacking, if already in, just increase quantity instead of adding to list
        if (!quantityCheck(items, itemAdded))
        {
            items.Add(itemAdded);
        }
        else
        {
            items[items.IndexOf(itemAdded)].quantity++;
        }

        //Add specific item to item type list:
        if(itemAdded.itemType == Item.ItemType.Quest)
        {
            quests.Add(itemAdded);
        }
        if(itemAdded.itemType == Item.ItemType.Resource)
        {
            if (!quantityCheck(resources, itemAdded))
            {
                resources.Add(itemAdded);
            }
        }
        if(itemAdded.itemType == Item.ItemType.Consumable)
        {
            if (!quantityCheck(consumables, itemAdded))
            {
                consumables.Add(itemAdded);
            }
        }
        if (itemAdded.itemType == Item.ItemType.Armor)
        {
            if (!quantityCheck(armor, itemAdded))
            {
                armor.Add(itemAdded);
            }
        }
        if (itemAdded.itemType == Item.ItemType.Shield)
        {
            if (!quantityCheck(shields, itemAdded))
            {
                shields.Add(itemAdded);
            }
        }
        if (itemAdded.itemType == Item.ItemType.Weapon)
        {
            if (!quantityCheck(weapons, itemAdded))
            {
                weapons.Add(itemAdded);
            }
        }
        if (itemAdded.itemType == Item.ItemType.Craftable)
        {
            if (!quantityCheck(craftables, itemAdded))
            {
                craftables.Add(itemAdded);
            }
        }

        UIEventHandler.ItemAddedToInventory(itemAdded);

        //Adds to event and calls everything subscribed to event, so all inventory gets updated and displayed
        if (onItemChangedCallback != null)
        {
            //Triggering event to update UI
            onItemChangedCallback.Invoke();
        }

    }

    //Removes item from list, after it is consumed or anything happens to it
    public void Remove(Item item)
    {
        if(item.quantity > 1)
        {
            item.quantity--;
            UIEventHandler.ItemAddedToInventory(item);

            if (onItemChangedCallback != null)
            {
                //Triggering event to update UI
                onItemChangedCallback.Invoke();
            }

            return;
        }

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
        if (item.itemType == Item.ItemType.Craftable)
        {
            craftables.Remove(item);
        }

        if (onItemChangedCallback != null)
        {
            //Triggering event to update UI
            onItemChangedCallback.Invoke();
        }

    }

    //Returns true if item reaches max stack value of 99
    private bool checkLimit(Item item)
    {
        if(item.quantity == MAXSTACKSIZE)
        {
            return true;
        }

        return false;
    }

    //Methods for displaying item info, one for each tab inventory
    public void setConsumablesItemDetails(Item item, Button button)
    {
        ConsumablesDetailsPanel.setItem(item, button);
    }

    public void setWeaponsItemDetails(Item item, Button button)
    {
        WeaponsDetailsPanel.setItem(item, button);
    }

    public void setArmorItemDetails(Item item, Button button)
    {
        ArmorDetailsPanel.setItem(item, button);
    }

    public void setShieldsDetails(Item item, Button button)
    {
        ShieldsDetailsPanel.setItem(item, button);
    }

    public void setResourcesDetails(Item item, Button button)
    {
        ResourcesDetailsPanel.setItem(item, button);
    }
    public void setCraftablesDetails(Item item, Button button)
    {
        CraftablesDetailsPanel.setItem(item, button);
    }

    //Equiping item from inventory code:
    //Add equip weapons later

    //Consumables:
    public void ConsumeItem(Item consumedItem)
    {
        consumableController.consumeItem(consumedItem);
    }

    public bool ResourcesCheck(string item1, int quant)
    {
        foreach (Item child in resources)
        {
            if ((child.name == item1) && (child.quantity >= quant))
            {
                return true;
            }
        }
        return false;
    }

    public void ResourcesRemove(string item1, int quant)
    {
        foreach (Item child in resources)
        {
            if ((child.name == item1))
            {
                for (int i = 0; i < quant; i++)
                {
                    Remove(child);
                }
            }
        }
    }

    //Check if list already has item, if so just increase quantity. Returns true if item already in list, false otherwise:
    public bool quantityCheck(List<Item> items, Item itemAdded)
    {
        if (items.Contains(itemAdded))
        {
            return true;
        }
        return false;
    }
}
