using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySkillPoints : MonoBehaviour {

    public GameObject player;
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
        this.GetComponent<Text>().text = "Skill Points: " + player.GetComponent<CharacterStat>().GetSkillPoints().ToString();
=======
        this.GetComponent<Text>().text = "Stat Points: " + player.GetComponent<CharacterStat>().GetSkillPoints().ToString();
>>>>>>> 888d8030b92e22083a5db6531b8c75e0e7770ce5
	}
}
