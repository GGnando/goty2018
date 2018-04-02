using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base class for quest goals/objectives. What the player has to do
public class Objective  {
    public string description; //Description of what the objective is
    public bool completed; //False if quest objective is not done yet
    public int currProgress; //int of current progress. Ex. kill 5 enemies curr would be 0 at start
    public int endAmount; //int of end amount needed to finish objective

    //Initialization method for objective
    public virtual void initialization()
    {
        //Base functionality if needed here
        //Extended by other types of objectives for different initilization needs
    }

    //Checks progress of objective. Calls completed when required amount is reached
    public void progress()
    {
        if(currProgress >= endAmount)
        {
            completion();
        }
    }

    //Quest is completed
    public void completion()
    {
        completed = true;
    }
}
