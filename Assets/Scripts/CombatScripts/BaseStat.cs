
using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD:Assets/Scripts/CombatScripts/BaseStat.cs
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class BaseStat {
    //each stat holds a list of bonusstats
    public List<BonusStat> bonusStats;
    
    [JsonConverter(typeof(StringEnumConverter))]
    public StatType type;
    public float baseValue;
    public string name;
    public string discription;
    public float totalValue;

=======
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
>>>>>>> 888d8030b92e22083a5db6531b8c75e0e7770ce5:Assets/Scripts/Stats Scripts/BaseStat.cs
    [Newtonsoft.Json.JsonConstructor]
    public BaseStat(StatType type, float baseValue, string name, string discription) {
        this.type = type;
        bonusStats = new List<BonusStat>();
        this.baseValue = baseValue;
        this.name = name;
        this.discription = discription;
        totalValue = baseValue;
    }

    public void addBonus(BonusStat bonus) {
        bonusStats.Add(bonus);
        calculateTotal();
    }

    public void removeBonus(BonusStat bonus) {
        bonusStats.Remove(bonusStats.Find(x=>x.bonus == bonus.bonus));
        calculateTotal();
    }
    //this function is called everytime a bonus is added or removed. Done in order to keep totalValue up to date
    private void calculateTotal() {
        float extraBonus = 0;
        foreach (BonusStat element in bonusStats) {
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



