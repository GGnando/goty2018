using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSounds : MonoBehaviour {
  
    public void GoblinLaugh()
    {
        FindObjectOfType<DialogueAudio>().GoblinLaugh();
    }

    public void GoblinSwing()
    {
        FindObjectOfType<DialogueAudio>().GoblinSwing();
    }
}
