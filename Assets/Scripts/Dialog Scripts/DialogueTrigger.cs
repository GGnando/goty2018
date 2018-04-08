using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this is essentially supposed to be the NPC script from the other video. I think normally you would attatch this to whatever NPC character you wanted. 
//to make a new NPC thing with a new dialogue you would have to create an empty object. Reset its transform. Name the empty object the name of the NPC.
//attatch the dialogue trigger to this new game object. Change the name in the dialogue parameter to the name of the NPC. And then give her some sentences to say
public class DialogueTrigger : MonoBehaviour {
    public Dialogue dialogue; //using the data type that we just created. The dialogue class. 
    //way to feed stuff to our dialogue manager
    public void TriggerDialogue()
    {
        //we want to find an object of type DialogueManager. And now that we found this object we want to call the function StartDialogue and give it a function
        //argument to tell it what conversation to start (we pass in our dialogue variable. 
        FindObjectOfType<DialogueManager>().KnightButtonOnOrOff(0); //turn the button off because they want to start conversatoin
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);  //locate our dialogue manager. 
    }

    //functoin that makes the start conversation button appear
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) //if the Player enters our collider
        {
            FindObjectOfType<DialogueManager>().KnightButtonOnOrOff(1); //turn the conversatoin button on
        }
    }

    //function that makes the start conversation button dissapear
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) //if the Player leaves our collider
        {
            FindObjectOfType<DialogueManager>().KnightButtonOnOrOff(0); //make the start conversation button go aawy
        }
    }

    //Tyler stuff:
    public void TylerTriggerDialogue()
    {
        //we want to find an object of type DialogueManager. And now that we found this object we want to call the function StartDialogue and give it a function
        //argument to tell it what conversation to start (we pass in our dialogue variable. 
        FindObjectOfType<DialogueManager>().TylerKnightButtonOnOrOff(0); //turn the button off because they want to start conversatoin
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);  //locate our dialogue manager. 
    }
}
