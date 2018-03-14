using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour, IEnemy {

	private float currentHealth;
    public float MaxHealth, attackDamage;
	void Start () {
        MaxHealth = 100;
        attackDamage = 2;
        currentHealth = 100;
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
        Destroy(gameObject);
    }
}
