
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is an example of a quest, where the player has to pick up 3 wood
public class collectWoodQuest : Quest {

    private void Start()
    {
        Debug.Log("Quest started");
        //Simple way to make a quest, just fill out all properties and add to objective list
        questName = "Collect 3 wood";
        questDescription = "Help the village with cutting wood";

        itemReward = "Iron Shield";

        experienceAward = 10;

        objectives.Add(new CollectObjective(this, "Wood", questDescription, false, 0, 3));

        objectives.ForEach(g => g.initialization()); //Loop through all objectives for quest and initialize them
    }
}
*/