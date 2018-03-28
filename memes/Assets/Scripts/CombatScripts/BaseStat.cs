
using System.Collections;
using System.Collections.Generic;
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
    public string getDiscription() {
        return discription;
    }
    public void setDiscription(string discription) {
        this.discription = discription;
    }
    public float getTotalValue() {
        return totalValue;
    }

}