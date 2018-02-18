using UnityEngine;

public class ItemPickup : Interactables {

    //Allows accessing features of items, such as names
    public Item item;

    public override void interact()
    {
        base.interact();

        pickUp();
    }

    void pickUp()
    {
        Debug.Log("Picking up " + item.name);

        //Add to inventory
        //If we didnt create instance in inventory class, would have to write long code
        //Now can just use
        Inventory.instance.Add(item);

        //Remove object from world
        Destroy(gameObject);
    }
}