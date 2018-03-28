using UnityEngine;
using UnityEngine.UI;

//This class keeps track of inventory and updates it
public class InventoryUI : MonoBehaviour {

    //Reference to item slot's parent. Used to loop through and pick item slot
    //public Transform itemsParent;

    //Reference to entire inventory
    public GameObject inventoryUI;

    //Array to keep track and use inventory slots 
    //InventorySlot[] itemSlots;

    //Stores inventory in variable
    Inventory inventory;

    //[SerializeField] GameObject itemSlotPrefab;

    //Reference to inventoryUI panel, scrollArea
    public RectTransform inventoryPanel;
    public RectTransform scrollViewContent;

    //Reference to itemContainer prefab for item slots
    InventoryUIItem itemContainer;

    //See if inventory UI is active
    bool isInventoryActive;

    //Know which item is currently selected to display info
    Item currentSelectedItem { get; set; }

    void Start () {
        /*
        //Set inventory and update UI
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += updateUI;

        //This calls the parent to get all slots and add to array
        itemSlots = itemsParent.GetComponentsInChildren<InventorySlot>();

        */

        //Loads item container prefab for inventory slots
        itemContainer = Resources.Load<InventoryUIItem>("InventoryUI/ItemContainer");

        //Inventory panel is off tp start
        //inventoryPanel.gameObject.SetActive(false);

        //Helps UI know which item added to inventory. Event is known
        UIEventHandler.OnItemAddedToInventory += itemAdded;
	}

    //So UI knows is added
    public void itemAdded(Item item)
    {
        //Updates Inventory UI to add more items
        //Because of event system, adds these
        InventoryUIItem emptyItem = Instantiate(itemContainer);
        emptyItem.setItem(item);
        emptyItem.transform.SetParent(scrollViewContent);
    }
	
	void Update () {
        //To pull up and get off of inventory, look for inventory key press
        if (Input.GetButtonDown("Inventory"))
        {
           //Does opposite of whatever is up, so if inventory is pulled up, pressing again closes it
           inventoryUI.SetActive(!inventoryUI.activeSelf);
           //inventoryPanel.gameObject.SetActive(!inventoryPanel.gameObject.activeSelf);
        }
	}

    /*
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
