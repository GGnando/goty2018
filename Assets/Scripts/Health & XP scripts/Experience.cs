using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour {

	public GameObject experienceBar;
	public GameObject experienceText;
	float barLength;

    int playerLevel;
    int currentXP;
    int xpToLevelUp;

	// Use this for initialization
	void Start () {
		experienceText.GetComponent<Text> ().enabled = false;
        playerLevel = 1;
        currentXP = 0;
        xpToLevelUp = 100;
	}

	void Update () {
		barLength = (1.0f * currentXP / xpToLevelUp) * 2.75f;
		experienceBar.GetComponent<RectTransform>().localScale = new Vector3(barLength,0.175f,1.0f);
		experienceText.GetComponent<Text> ().text = currentXP.ToString() + " / " + xpToLevelUp.ToString();
	}

    private void LevelUp()
    {
        playerLevel++;
        // TODO Upgrade player Stats
        // TODO Give skill points
        currentXP = currentXP - xpToLevelUp;
        xpToLevelUp += 100;
        print("Player has leveled up and is now level: ");
        print(playerLevel);
    }

    public void AddXP(int amount)
    {
        currentXP += amount;
        if (currentXP >= xpToLevelUp)
            LevelUp();
    }

	void OnMouseEnter() {
		experienceText.GetComponent<Text> ().enabled = true;
	}

	void OnMouseExit() {
		experienceText.GetComponent<Text> ().enabled = false;
	}
}
