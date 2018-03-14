
using System.Collections;
using System.Collections.Generic;


public class BaseStat {

    public List<BonusStat> bonusStats;
    private float baseValue;
    private string name;
    private string discription;
    private float totalValue;

    public BaseStat(float baseValue, string name, string discription) {
        bonusStats = new List<BonusStat>();
        this.baseValue = baseValue;
        this.name = name;
        this.name = discription;
        totalValue = baseValue;
    }

    public void addBonus(BonusStat bonus) {
        bonusStats.Add(bonus);
        calculateTotal();
    }

    public void removeBonus(BonusStat bonus) {
        bonusStats.Remove(bonus);
        calculateTotal();
    }

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