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
        this.transform.Find("ItemIcon").GetComponent<Image>().sprite = Resources.Load<Sprite>("InventoryUI/icons/png/64px/" + item.name);

        //Only show quantity of item if greater than 1 and is stackable
        //if(item.quantity > 1 && item.stackable && item.quantity < 100)
        //{
            //this.transform.Find("Quantity").GetComponent<Text>().text = 
        //}
    }

    public void selectItemButton()
    {
        //Displays info to info panel in inventory
        //Inventory.instance.setItemDetails(item, GetComponent<Button>());

        //Add specific item to item type list:
        /*
        if (item.itemType == Item.ItemType.Resource)
        {
            Inventory.instance.setResourcesDetails(item, GetComponent<Button>());
        }
        */
        if (item.itemType == Item.ItemType.Consumable)
        {
            Inventory.instance.setConsumablesItemDetails(item, GetComponent<Button>());
        }
        if (item.itemType == Item.ItemType.Armor)
        {
            Inventory.instance.setArmorItemDetails(item, GetComponent<Button>());
        }
        if (item.itemType == Item.ItemType.Shield)
        {
            Inventory.instance.setShieldsDetails(item, GetComponent<Button>());
        }
        if (item.itemType == Item.ItemType.Weapon)
        {
            Inventory.instance.setWeaponsItemDetails(item, GetComponent<Button>());
        }
    }
}
