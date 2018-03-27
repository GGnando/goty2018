
using System.Collections;
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
	public GameObject player;
    private int skillPoints = 0;
	private int usedSkillPoints = 0;

    // Use this for initialization
    void Start()
    {
        stats.Add(new BaseStat(1, "Attack", "Melee damage"));
        stats.Add(new BaseStat(1, "Ranged", "Ranged damage"));
        stats.Add(new BaseStat(1, "Magic", "Magic damage"));
        stats.Add(new BaseStat(1, "Defense", "Defense amount"));
        stats.Add(new BaseStat(1, "Constitution", "9001"));
        stats.Add(new BaseStat(1, "Vitality", "9001"));
    }
     
	
	// Update is called once per frame
	void Update () {
		
	}

    public int GetSkillPoints() { return skillPoints; }
    public void SetSkillPoints(int skillPoints) { this.skillPoints = skillPoints; }
	public void UseSkillPoint() {
		if (skillPoints > 0)
			skillPoints--; 
	}
	public void GainSkillPoint() {  
			skillPoints++; 
	}

	public List<BaseStat> GetStats() {
		return stats;
	}

	public int GetStat(int statNumber) {
		return (int)stats [statNumber].getBaseValue();
	}


}