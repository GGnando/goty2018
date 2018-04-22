using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PauseGame : MonoBehaviour {
    public Transform Canvas;
    public Transform soundsMenu;
    public Transform pauseMenu;
    public Transform controlMenu;
    public Transform videoMenu;
    public Transform player;
    Event keyEvent;
    Text buttonText;
    KeyCode newKey;

    bool waitingForKey;

    void Awake()
    {
        //LoadGameSettings();
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(GameManager.GM.forward))
        {
            Pause();
        }	
	}

    public void Pause ()
    {
        if (Canvas.gameObject.activeInHierarchy == false)
        {
            if(pauseMenu.gameObject.activeInHierarchy == false)
            {
                pauseMenu.gameObject.SetActive(true);
                soundsMenu.gameObject.SetActive(false);
                controlMenu.gameObject.SetActive(false);
                videoMenu.gameObject.SetActive(false);
            }
            Canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            //player.GetComponent<ThirdPersonUserControl>().enabled = false;
        }
        else
        {
            Canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            //player.GetComponent<ThirdPersonUserControl>().enabled = true;
        }
    }

    public void LoadGameSettings()
    {
        Inventory inventory = player.GetComponent<Inventory>();
        player.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z")); //Upon restart load game
        player.eulerAngles = new Vector3(0, PlayerPrefs.GetFloat("Cam_y"));
        for(int i = 0; i < PlayerPrefs.GetInt("numItems"); i++)
        {
            inventory.Add(PlayerPrefs.GetString("Item_" + i));
        }
    }

    public void Sounds(bool Open)
    {
        if (Open)
        {
            soundsMenu.gameObject.SetActive(true);
            pauseMenu.gameObject.SetActive(false);
        }
        if (!Open)
        {
            soundsMenu.gameObject.SetActive(false);
            pauseMenu.gameObject.SetActive(true);
        }
    }

    public void Controls(bool Open)
    {
        if (Open)
        {
            controlMenu.gameObject.SetActive(true);
            pauseMenu.gameObject.SetActive(false);
        }
        if (!Open)
        {
            controlMenu.gameObject.SetActive(false);
            pauseMenu.gameObject.SetActive(true);
        }
    }

    public void Video(bool Open)
    {
        if (Open)
        {
            videoMenu.gameObject.SetActive(true);
            pauseMenu.gameObject.SetActive(false);
        }
        if (!Open)
        {
            videoMenu.gameObject.SetActive(false);
            pauseMenu.gameObject.SetActive(true);
        }
    }

    public static void pauseGame()
    {
        Time.timeScale = 0;
    }

    public static void unpauseGame()
    {
        Time.timeScale = 1;
    }
}
