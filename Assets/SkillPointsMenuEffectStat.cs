using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPointsMenuEffectStat : MonoBehaviour {

	public GameObject player;
	public Text skillText;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void IncreasePlayerStat(int statNumber) {
		if (player.GetComponent<CharacterStat> ().GetSkillPoints () > 0) {
			int originalValue = (int)player.GetComponent<CharacterStat> ().GetStats () [statNumber].getBaseValue ();
			player.GetComponent<CharacterStat> ().GetStats () [statNumber].setBaseValue (originalValue + 1);

			string skillName = player.GetComponent<CharacterStat> ().GetStats () [statNumber].getName ();
			skillText.text = skillName + ": " + player.GetComponent<CharacterStat> ().GetStat (statNumber).ToString ();


			player.GetComponent<CharacterStat> ().SetSkillPoints( player.GetComponent<CharacterStat> ().GetSkillPoints()-1);
		}
	}

	public void DecreasePlayerStat(int statNumber) {
		int originalValue = (int)player.GetComponent<CharacterStat> ().GetStats () [statNumber].getBaseValue ();
		if (originalValue > 1) {
			player.GetComponent<CharacterStat> ().GetStats () [statNumber].setBaseValue (originalValue - 1);
			string skillName = player.GetComponent<CharacterStat> ().GetStats () [statNumber].getName ();
			skillText.text = skillName + ": " + player.GetComponent<CharacterStat> ().GetStat (statNumber).ToString ();

			player.GetComponent<CharacterStat> ().SetSkillPoints( player.GetComponent<CharacterStat> ().GetSkillPoints()+1);

		}
	}
}
