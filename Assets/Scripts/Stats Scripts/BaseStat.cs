using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStat : MonoBehaviour {

    public List<BonusStat> bonusStats;

    public float baseValue;
    public string name; //Changed to public for test
    public string description;
    public float totalValue;

    public BaseStat(float baseValue, string name, string description) {
        bonusStats = new List<BonusStat>();
        this.baseValue = baseValue;
        this.name = name;
		this.description = description;
        totalValue = baseValue;
    }

    //Constructor for json file for items
    [Newtonsoft.Json.JsonConstructor]
    public BaseStat(float baseValue, string name)
    {
        bonusStats = new List<BonusStat>();
        this.baseValue = baseValue;
        this.name = name;
        totalValue = baseValue;
    }

    public void addStatBonus(BonusStat bonus) {
        bonusStats.Add(bonus);
        calculateTotal();
    }

    public void removeBonus(BonusStat bonus) {
        bonusStats.Remove(bonus);
        calculateTotal();
    }

    private void calculateTotal() {
        float extraBonus = 0;
        foreach(BonusStat element in bonusStats) {
            extraBonus += element.bonus;
        }
        totalValue = baseValue + extraBonus;
    }

    /// 
    /// public get and set functions for data members
    /// 
    public float getBaseValue() {
        return baseValue;
    }
    public void setBaseValue(float baseValue) {
        this.baseValue = baseValue;
    }
    public string getName() {
        return name;
    }
    public void setName(string name) {
        this.name = name;
    }
    public string getDescription() {
        return description;
    }
    public void setDescription(string description) {
        this.description = description;
    }
    public float getTotalValue() {
        return totalValue;
    }
    public void setTotalValue(float totalValue)
    {
        this.totalValue = totalValue;
    }


}



