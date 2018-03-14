

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatType {
    Attack,
    Ranged,
    Magic,
    Defense,
    Constitution,
    Vitality
}

public class CharacterStat : MonoBehaviour {

    public List<BaseStat> stats;
    // Use this for initialization
    void Start() {
        stats = new List<BaseStat>();
        stats.Add(new BaseStat(3, "Attack", "9001"));
        stats.Add(new BaseStat(3, "Ranged", "9001"));
        stats.Add(new BaseStat(3, "Magic", "9001"));
        stats.Add(new BaseStat(3, "Defense", "9001"));
        stats.Add(new BaseStat(3, "Constitution", "9001"));
        stats.Add(new BaseStat(3, "Vitality", "9001"));
    }
    //newBonusStats must follow proper indexing into character stat list
    //ex: newBonusStats[0] = Attack, newBonusStats[1] = ranged
    public void AddStatBonus(List<BonusStat> newBonusStats) {
        IEnumerator iterator = newBonusStats.GetEnumerator();
        iterator.MoveNext();
        foreach (BaseStat stat in stats) {
            stat.addBonus((BonusStat)iterator.Current);
            iterator.MoveNext();
        }
    }

    public void RemoveStatBonus(List<BonusStat> newBonusStats) {
        IEnumerator iterator = newBonusStats.GetEnumerator();
        iterator.MoveNext();
        foreach (BaseStat stat in stats) {
            stat.removeBonus((BonusStat)iterator.Current);
            iterator.MoveNext();
        }
    }

    // Update is called once per frame
    void Update() {

    }
}

