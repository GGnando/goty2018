using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public GameObject healthBar;
    float barLength;

    int totalHealth;
    int currentHealth;


	// Use this for initialization
	void Start () {
        totalHealth = 100;
        currentHealth = totalHealth;
	}
	
	// Update is called once per frame
	void Update () {
        barLength = (1.0f * currentHealth / totalHealth) * 2.25f;
        healthBar.GetComponent<RectTransform>().localScale = new Vector3(barLength,0.2f,1.0f);
	}

    public void TakeDamage(int damageAmount)
    {
        if (currentHealth - damageAmount < 0)
        {
            currentHealth = 0;
        }
        else
            currentHealth -= damageAmount;
    }

    public void Heal(int healAmount)
    {
        if (currentHealth + healAmount > totalHealth)
        {
            currentHealth = totalHealth;
        }
        else
            currentHealth += healAmount;
    }
}
