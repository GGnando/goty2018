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
    public double weight;
    public int durability;
    public int quantity;
    public string interactName; //Interact name on button for inventory
    public bool craftable;

    public enum ItemType
    {
        Quest, Consumable, Resource, Shield, Weapon, Armor
    }

    public Item(string n, Sprite i, string d, ItemType t, bool s, bool st, int c, double w, int du, int q, string iname, bool cra)
    {
        name = n;
        icon = i;
        itemDescription = d;
        itemType = t;
        sellable = s;
        stackable = st;
        itemCost = c;
        weight = w;
        durability = du;
        quantity = q;
        interactName = iname;
        craftable = cra;
    }

    public virtual void use()
    {
        //Use item. Virtual to be expanded upon for specific items

        Debug.Log("Using " + name);
    }
}
