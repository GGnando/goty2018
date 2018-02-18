using UnityEngine;

//Allows you to create new item in unity easily 
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    //Blueprint for all items. Shared by them all. Add more later
    new public string name = "New Item";
    public Sprite icon = null;
    public string itemDescription = "Description";
    public ItemType itemType;
    public bool sellable;
    public bool stackable;
    public int itemCost;
    public int weight;
    public int durability;
    public int quantity;
    public bool consumable;
    public bool craftable;

    public enum ItemType
    {
        Quest, Consumable, Resource, Shield, Weapon, Armor
    }

    public virtual void use()
    {
        //Use item. Virtual to be expanded upon for specific items

        Debug.Log("Using " + name);
    }
}
