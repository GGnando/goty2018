<<<<<<< HEAD:Assets/Scripts/Stats Scripts/CharacterStat.cs
﻿
using System.Collections;
=======
﻿using System.Collections;
>>>>>>> Ryan2:Assets/Scripts/CharacterStat.cs
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour {
    public enum StatType {
        Attack,
        Ranged,
        Magic,
        Defense,
        Constitution,
        Vitality
    }

    public List<BaseStat> stats = new List<BaseStat>();
<<<<<<< HEAD:Assets/Scripts/Stats Scripts/CharacterStat.cs
	// Use this for initialization
	void Start () {
        /*
        stats[Attack] = new BaseStat(3,"Attack", "9001");
        stats[Ranged] = new BaseStat(3, "Ranged", "9001");
        stats[Magic] = new BaseStat(3, "Magic", "9001");
        stats[Defense] = new BaseStat(3, "Defense", "9001");
        stats[Constitution] = new BaseStat(3, "Constitution", "9001");
        stats[Vitality] = new BaseStat(3, "Vitality", "9001");
        */
=======
    private int skillPoints = 0;

    // Use this for initialization
    void Start()
    {
        stats.Add(new BaseStat(1, "Attack", "Melee damage"));
        stats.Add(new BaseStat(1, "Ranged", "Ranged damage"));
        stats.Add(new BaseStat(1, "Magic", "Magic damage"));
        stats.Add(new BaseStat(1, "Defense", "Defense amount"));
        stats.Add(new BaseStat(1, "Constitution", "9001"));
        stats.Add(new BaseStat(1, "Vitality", "9001"));
>>>>>>> Ryan2:Assets/Scripts/CharacterStat.cs
    }
     
	
	// Update is called once per frame
	void Update () {
		
	}

    public int GetSkillPoints() { return skillPoints; }
    public void SetSkillPoints(int skillPoints) { this.skillPoints = skillPoints; }
}
<<<<<<< HEAD:Assets/Scripts/Stats Scripts/CharacterStat.cs
=======

>>>>>>> Ryan2:Assets/Scripts/CharacterStat.cs
