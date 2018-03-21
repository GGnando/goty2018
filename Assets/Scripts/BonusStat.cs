using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Modifier {
    Multiplicitive,
    Additive
}

public class BonusStat : MonoBehaviour {

    public float bonus;
    public string name;
    public string description;
    public Modifier modType;
    
    public BonusStat(float bonus, string name, string description, Modifier modType) {
        this.bonus = bonus;
        this.name = name;
        this.description = description;
        this.modType = modType;
    }
}
