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
    public float rotation_x;
    public float rotation_y;
    public float rotation_z;
    public float position_x;
    public float position_y;
    public float position_z;
    public Quaternion localRotation;
    public Vector3 localPosition;
    public string animationKey;

    public enum ItemType
    {
        Quest, Consumable, Resource, Shield, Weapon, Armor
    }

    //json constructor for items
    [Newtonsoft.Json.JsonConstructor]
    public Item(string n, string d, ItemType t, bool s, bool st, int c, double w, int du, int q, string iname, bool cra, List<BaseStat> sta, bool eff, float rx, float ry, float rz,
                float px, float py, float pz, string ak) {
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
        rotation_x = rx;
        rotation_y = ry;
        rotation_z = rz;
        position_x = px;
        position_y = py;
        position_z = pz;
        animationKey = ak;
}
    public Item(string n, Quaternion lr, Vector3 lp, string ak) {
        name = n;
        localRotation = lr;
        localPosition = lp;
        animationKey = ak;
    }
    public virtual void use()
    {
        //Use item. Virtual to be expanded upon for specific items

        Debug.Log("Using " + name);
    }
}
