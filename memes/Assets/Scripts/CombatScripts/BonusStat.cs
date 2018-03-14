
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Modifier {
    Multiplicitive,
    Additive
}

public class BonusStat {

    public float bonus;
    public StatType stat;
    public string discription;
    public Modifier modType;

    public BonusStat(float bonus, StatType stat, string discription, Modifier modType) {
        this.bonus = bonus;
        this.stat = stat;
        this.discription = discription;
        this.modType = modType;
    }
}
