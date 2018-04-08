using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; //library to help with quest objectives

public class Quest : MonoBehaviour {

    //Basis for quest will have objectives, a name, description, XP reward, item reward, and bool to see if complete
    public List<Objective> objectives = new List<Objective>();
    public string questName;
    public string questDescription;
    public int experienceAward;
    public string itemReward;
    public bool isComplete;

    public GameObject player; //Reference to player to give xp

    public Quest()
    {

    }

    public Quest(List<Objective> objs, string name, string desc, int xpAward, string itemR, bool isDone)
    {
        objectives = objs;
        questName = name;
        questDescription = desc;
        experienceAward = xpAward;
        itemReward = itemR;
        isComplete = isDone;
    }

    public void checkObjectives()
    {
        isComplete = objectives.All(g => g.completed); //Goes through objectives to see if one objective is not completed

        //Give reward if quest is complete
        if (isComplete)
        {
            giveReward();
            //Let quest giver give reward and remove required items
        }
    }

    void giveReward()
    {
        Debug.Log("Quest was completed");
        if (itemReward != null)
        {
            //If item reward exsits, add to inventory once completed
            Inventory.instance.Add(itemReward);
        }

        if (experienceAward != 0)
        {
            //If experience award exsits, give xp to player
            player.GetComponent<Experience>().AddXP(experienceAward);
        }

        itemReward = null;
        experienceAward = 0;
    }
}
