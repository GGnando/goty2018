using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public CharacterStat playerStats;
	// Use this for initialization

	void Awake () {
        //attack, defense, consitution, vitality
        playerStats = new CharacterStat(10, 10, 50, 50);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
