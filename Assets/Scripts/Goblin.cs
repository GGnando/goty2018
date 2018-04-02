using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour, IEnemy {

	private float currentHealth;
    public float MaxHealth;
    private CharacterStat goblinStats;
    public DropTable dropTable;
    public ItemPickup goblinDrop;
    public int goblinID;
    static int IDCounter = 0;

	void Start () {
        goblinID = IDCounter++;
        //attack, defense, consitution, vitality
        goblinStats = new CharacterStat(10,10,50,50);
        currentHealth = MaxHealth = 50;
        dropTable = new DropTable();
        dropTable.listOfDrop = new List<LootDrop>() {
            new LootDrop("Sword",100),
            new LootDrop("Sword_2H",0),
            new LootDrop("Axe",0)
        };

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PerformAttack() {

    }
    public void TakeDamage(float damage) {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            Die();
        }
    }
    
    private void Die() {
        DropLoot();
        Destroy(gameObject);
    }
    private void DropLoot() {
        Item potentialDrop = dropTable.getDrop();
        if(potentialDrop != null) {
            GameObject weapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/ScriptedWeapons/" + potentialDrop.name), transform.position, Quaternion.identity);
            ItemPickup temp = weapon.GetComponent<ItemPickup>();
            temp.item = potentialDrop;
        }
    }
}
