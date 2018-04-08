using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This will be an objective for collecting a certain amount of items
public class CollectObjective : Objective {

    //itemName will be the name of the item needed to be collected
    public string itemName;

    //Constructor for collect objective
    public CollectObjective(Quest quest, string itemName, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.quest = quest;
        this.itemName = itemName;
        this.description = description;
        this.completed = completed;
        this.currProgress = currentAmount;
        this.endAmount = requiredAmount;
    }

    public override void initialization()
    {
        base.initialization();
        UIEventHandler.OnItemAddedToInventory += itemPickedUp; //Event caller that adds below method to check for items picked up
    }

    void itemPickedUp(Item item)
    {
        if(item.name == this.itemName)
        {
            this.currProgress++;
            progress();
        }
    }
}
