using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIDetails : MonoBehaviour {

    Item item; //Item selected
    Button selectedItemButton; //Button to item selected
    Button itemInteractButton; //Button to interact with item
    Text itemName; //Name of item to appear in details panel
    Text itemDescriptionText; //Description of item to appear
    Text itemButtonText; //Button text when interacting with it

    public Text statText; //Text of stats of item

    void Start()
    {
        //Setting all the information for the panel
        itemName = transform.Find("ItemName").GetComponent<Text>();
        itemDescriptionText = transform.Find("ItemDescription").GetComponent<Text>();
        itemInteractButton = transform.Find("Button").GetComponent<Button>();
        itemButtonText = itemInteractButton.transform.Find("Text").GetComponent<Text>();

        //When no item selected, just deactivated
        gameObject.SetActive(false);
    }
    //Set item to display info on side of items
    public void setItem(Item item, Button button)
    {
        //Show details when object selected
        gameObject.SetActive(true);

        //Setting stat text here now: 
        statText.text = "";

        //If item does not have stats, don't display. If so, loop through and display all
        if(item.stats != null)
        {
            foreach(BaseStat stat in item.stats)
            {
                statText.text += stat.name + ": " + stat.baseValue + "\n";
            }
        }

        //Remove previous listeners for events or everything used will be done multiple times:
        itemInteractButton.onClick.RemoveAllListeners();

        //Setting information for details pannel to show
        this.item = item;
        selectedItemButton = button;
        itemName.text = item.name;
        itemDescriptionText.text = item.itemDescription;
        itemButtonText.text = item.interactName;

        //When button clicked to interact with item, call below method
        itemInteractButton.onClick.AddListener(onItemInteract); 
    }

    //Actually use item time
    public void onItemInteract()
    {
        //Depending on type of item, interact in other ways
        if(item.itemType == Item.ItemType.Consumable)
        {
            Inventory.instance.ConsumeItem(item);
            Destroy(selectedItemButton.gameObject);
        }
        //else if for weapon here

        //Null item after using and hide item details when not on something
        item = null;
        gameObject.SetActive(false);
        
    }
}
