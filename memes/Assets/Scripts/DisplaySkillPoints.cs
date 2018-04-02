using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySkillPoints : MonoBehaviour {

    public GameObject player;
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Text>().text = "Skill Points: " + player.GetComponent<CharacterStat>().GetSkillPoints().ToString();
	}
}
