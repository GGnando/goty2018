using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIItem : MonoBehaviour {

    public Item item;

    public void setItem(Item item)
    {
        //Grabs item to show info
        this.item = item;

        setUpItemValues();
    }

    void setUpItemValues()
    {
        //This gets child of UI panel for displaying item info. This will change the UI's text to the item's name
        this.transform.Find("ItemName").GetComponent<Text>().text = item.name;
        this.transform.Find("ItemIcon").GetComponent<Image>().sprite = item.icon;
    }

    public void selectItemButton()
    {
        //Displays info to info panel in inventory
        Inventory.instance.setItemDetails(item, GetComponent<Button>());
    }
}
