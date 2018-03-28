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

    public void setUpItemValues()
    {
        //This gets child of UI panel for displaying item info. This will change the UI's text to the item's name
        this.transform.Find("ItemName").GetComponent<Text>().text = item.name;
        this.transform.Find("ItemIcon").GetComponent<Image>().sprite = Resources.Load<Sprite>("InventoryUI/icons/png/64px/" + item.name);
        this.transform.Find("Quantity").GetComponent<Text>().text = "x" + item.quantity.ToString();
    }

    //This means an item was selected and the details of item must be shown. Calls the method for given tab's inventory
    public void selectItemButton()
    {
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
        if (item.itemType == Item.ItemType.Resource)
        {
            Inventory.instance.setResourcesDetails(item, GetComponent<Button>());
        }
    }
}
