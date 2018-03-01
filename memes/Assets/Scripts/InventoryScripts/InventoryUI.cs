using UnityEngine;
using UnityEngine.UI;

//This class keeps track of inventory and updates it
public class InventoryUI : MonoBehaviour {

    //Reference to item slot's parent. Used to loop through and pick item slot
    public Transform itemsParent;

    //Reference to entire inventory
    public GameObject inventoryUI;

    //Array to keep track and use inventory slots 
    InventorySlot[] itemSlots;

    //Stores inventory in variable
    Inventory inventory;

<<<<<<< HEAD
=======
    [SerializeField] GameObject itemSlotPrefab;

>>>>>>> Tyler-branch
    void Start () {
        //Set inventory and update UI
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += updateUI;

        //This calls the parent to get all slots and add to array
        itemSlots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}
	
	void Update () {
        //To pull up and get off of inventory, look for inventory key press
        if (Input.GetButtonDown("Inventory"))
        {
            //Does opposite of whatever is up, so if inventory is pulled up, pressing again closes it
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
	}

    void updateUI()
    {
        Debug.Log("Updating UI");

        //Go through all slots to add item
        for(int i = 0; i < itemSlots.Length; i++)
        {
            //Means inventory isnt full
            if(i < inventory.items.Count)
            {
<<<<<<< HEAD
=======
                GameObject itemSlot = Instantiate(itemSlotPrefab);

>>>>>>> Tyler-branch
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
}
