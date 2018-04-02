using UnityEngine;
using UnityEngine.UI;

//This class keeps track of inventory and updates it
public class InventoryUI : MonoBehaviour {

    //Reference to entire inventory
    public GameObject inventoryUI;

    //Stores inventory in variable
    Inventory inventory;

    //Reference to inventoryUI panel, scrollArea for each tab's inventory
    public RectTransform weaponsInventoryPanel;
    public RectTransform weaponsScrollViewContent;
    public RectTransform shieldsInventoryPanel;
    public RectTransform shieldsScrollViewContent;
    public RectTransform armorInventoryPanel;
    public RectTransform armorScrollViewContent;
    public RectTransform consumablesInventoryPanel;
    public RectTransform consumablesScrollViewContent;
    public RectTransform resourcesInventoryPanel;
    public RectTransform resourcesScrollViewContent;
    public RectTransform craftablesInventoryPanel;
    public RectTransform craftablesScrollViewContent;

    //Reference to itemContainer prefab for item slots
    InventoryUIItem itemContainer;

    //See if inventory UI is active
    bool isInventoryActive;

    //Know which item is currently selected to display info
    Item currentSelectedItem { get; set; }

    void Start () {
        //Loads item container prefab for inventory slots
        itemContainer = Resources.Load<InventoryUIItem>("InventoryUI/ItemContainer");

        //Helps UI know which item added to inventory. Event is known    
        UIEventHandler.OnItemAddedToInventory += itemAdded;
	}

    //So UI knows is added
    public void itemAdded(Item item)
    {
        //Updates Inventory UI to add more items
        //Because of event system, adds these

        //Creates a new item container which holds item information as UI element 
        InventoryUIItem emptyItem = Instantiate(itemContainer);

        //This deals with item stacking, if resources already has UI element with given item, delete current item UI and create a new one with updated quantity
        foreach (Transform child in resourcesScrollViewContent)
        {
            if(child.transform.Find("ItemName").GetComponent<Text>().text == item.name)
            {
                Destroy(child.gameObject);
            }   
        }

        //Set item information for UI
        emptyItem.setItem(item);

        //Assign item container to correct tab
        if (item.itemType == Item.ItemType.Resource)
        {
            emptyItem.transform.SetParent(resourcesScrollViewContent);
        }
        if (item.itemType == Item.ItemType.Consumable)
        {
            emptyItem.transform.SetParent(consumablesScrollViewContent);
        }
        if (item.itemType == Item.ItemType.Armor)
        {
            emptyItem.transform.SetParent(armorScrollViewContent);
        }
        if (item.itemType == Item.ItemType.Shield)
        {
            emptyItem.transform.SetParent(shieldsScrollViewContent);
        }
        if (item.itemType == Item.ItemType.Weapon)
        {
            emptyItem.transform.SetParent(weaponsScrollViewContent);
        }
        if (item.itemType == Item.ItemType.Craftable)
        {
            emptyItem.transform.SetParent(craftablesScrollViewContent);
        }
    }

    void Update () {
        //To pull up and get off of inventory, look for inventory key press
        if (Input.GetButtonDown("Inventory"))
        {
           //Does opposite of whatever is up, so if inventory is pulled up, pressing again closes it
           inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
	}

    /*
     * Out dated code that worked with inventoryslots script. Leaving for reference for future if curious of another method of implementation
    void updateUI()
    {
        Debug.Log("Updating UI");

        //Go through all slots to add item
        for(int i = 0; i < itemSlots.Length; i++)
        {
            //Means inventory isnt full
            if(i < inventory.items.Count)
            {
                GameObject itemSlot = Instantiate(itemSlotPrefab);

                //Add item to specific inventory slot
                itemSlots[i].addItem(inventory.items[i]);
            }
            else
            {
                //Out of inventory items to add
                itemSlots[i].clearSlot();
            }
        }

    }
    */
}
