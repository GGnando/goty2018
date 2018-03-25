using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Item {

    //Blueprint for all items. Shared by them all
    public string name;
    public string itemDescription;
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))] //Used to convert string to enum for json itemdase files
    public ItemType itemType;
    public bool sellable;
    public bool stackable;
    public int itemCost;
    public double weight;
    public int durability;
    public int quantity;
    public string interactName; //Interact name on button for inventory
    public bool craftable;
    public List<BaseStat> stats;
    public bool effectsStats; //True if item effects the player's stats (ex. health), false otherwise

    public enum ItemType
    {
        Quest, Consumable, Resource, Shield, Weapon, Armor
    }

    //json constructor for items
    [Newtonsoft.Json.JsonConstructor]
    public Item(string n, string d, ItemType t, bool s, bool st, int c, double w, int du, int q, string iname, bool cra, List<BaseStat> sta, bool eff)
    {
        name = n;
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
        stats = sta;
        effectsStats = eff;
    }

    public virtual void use()
    {
        //Use item. Virtual to be expanded upon for specific items

        Debug.Log("Using " + name);
    }
}
