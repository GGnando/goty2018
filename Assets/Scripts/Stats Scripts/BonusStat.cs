using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Modifier {
    Multiplicitive,
    Additive
}

public class BonusStat {

    public float bonus;
    public string name;
    public string discription;
    public Modifier modType;
    
    public BonusStat(float bonus, string name, string discription, Modifier modType) {
        this.bonus = bonus;
        this.name = name;
        this.discription = discription;
        this.modType = modType;
    }
}