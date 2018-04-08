using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goblin : MonoBehaviour, IEnemy {

	private float currentHealth;
    public float MaxHealth = 50;
    private CharacterStat goblinStats;
    public DropTable dropTable;
    public ItemPickup goblinDrop;
    public int goblinID;
    static int IDCounter = 0;
    public Image healthBar;
    public GameObject player;

	void Start () {
        goblinID = IDCounter++;
        //attack, defense, consitution, vitality
        goblinStats = new CharacterStat(10,10,50,50);
        currentHealth = MaxHealth;
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
        player.GetComponent<Health>().TakeDamage(5);
    }

    public void TakeDamage(float damage) {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth/MaxHealth;
        if (currentHealth <= 0) {
            Die();
        }
    }
    
    private void Die() {
        DropLoot();
        Destroy(gameObject);
        player.GetComponent<Experience>().AddXP(50);
    }
    private void DropLoot() {
        Item potentialDrop = dropTable.getDrop();
        if(potentialDrop != null) {
            GameObject weapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/ScriptedWeapons/" + potentialDrop.name), transform.position, Quaternion.identity);
            //ItemPickup temp = weapon.GetComponent<ItemPickup>();
            //temp.item = potentialDrop;
        }
    }
}
