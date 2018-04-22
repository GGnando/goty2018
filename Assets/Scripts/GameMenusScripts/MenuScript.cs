using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public Transform controlMenu;
    Event keyEvent;
    Text buttonText;
    KeyCode newKey;

    bool waitingForKey;

    // Use this for initialization
    void Start () {
        
        waitingForKey = false;
        for (int i = 0; i < controlMenu.childCount; i++) //for all the buttons corresponding to keys, skipping the back button
        {
            if (controlMenu.GetChild(i).name == "PauseButton")
                controlMenu.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.forward.ToString();
            else if (controlMenu.GetChild(i).name == "SkillButton")
                controlMenu.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.backward.ToString();
            else if (controlMenu.GetChild(i).name == "EquipButton")
                controlMenu.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.left.ToString();
            else if (controlMenu.GetChild(i).name == "InventoryButton")
                controlMenu.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.right.ToString();
            else if (controlMenu.GetChild(i).name == "JumpButton")
                controlMenu.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.jump.ToString();
            else if (controlMenu.GetChild(i).name == "AttackButton")
                controlMenu.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.attack.ToString();
        }
    }

    void OnGUI()
    {
        keyEvent = Event.current;
        if (keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }

    public void changeKey(string keyName)
    {
        if (!waitingForKey)
        {
            StartCoroutine(AssignKey(keyName));
        }
    }

    private IEnumerator waitForKey()
    {
        while (!keyEvent.isKey)
            yield return null;
    }

    public IEnumerator AssignKey(string keyName)
    {
        waitingForKey = true;

        yield return waitForKey();

        switch (keyName)
        {
            case "forward":
                GameManager.GM.forward = newKey;
                print(GameManager.GM.forward.ToString());
                buttonText.text = GameManager.GM.forward.ToString();
                PlayerPrefs.SetString("forwardKey", GameManager.GM.forward.ToString());
                break;
            case "backward":
                GameManager.GM.backward = newKey;
                buttonText.text = GameManager.GM.backward.ToString();
                PlayerPrefs.SetString("backwardKey", GameManager.GM.backward.ToString());
                break;
            case "left":
                GameManager.GM.left = newKey;
                buttonText.text = GameManager.GM.left.ToString();
                PlayerPrefs.SetString("leftKey", GameManager.GM.left.ToString());
                break;
            case "right":
                GameManager.GM.right = newKey;
                buttonText.text = GameManager.GM.right.ToString();
                PlayerPrefs.SetString("rightKey", GameManager.GM.right.ToString());
                break;
            case "jump":
                GameManager.GM.jump = newKey;
                buttonText.text = GameManager.GM.jump.ToString();
                PlayerPrefs.SetString("jumpKey", GameManager.GM.jump.ToString());
                break;
            case "attack":
                GameManager.GM.attack = newKey;
                buttonText.text = GameManager.GM.attack.ToString();
                PlayerPrefs.SetString("attackKey", GameManager.GM.attack.ToString());
                break;
        }
        yield return null;
    }

    public void SendText(Text text)
    {
        buttonText = text;//buttonText equals the parameter text being passed in
    }

    // Update is called once per frame
    void Update () {
		
	}
}
