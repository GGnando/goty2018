using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour {
    public Transform Player;
    public List<Item> items = new List<Item>();

    /*void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadGameSettings();
    }*/
    public void SaveGameSettings(bool Quit)
    {
        Inventory inventory = Player.GetComponent<Inventory>();
        items = inventory.getItems();
        PlayerPrefs.SetInt("numItems", items.Count);
        for(int i = 0; i < items.Count; i++)
        {
            PlayerPrefs.SetString("Item_" +i, items[i].name);
        }
        Scene scene = SceneManager.GetActiveScene();
        PlayerPrefs.SetFloat("x", Player.position.x); //saves x position to registry labeled 'x'
        PlayerPrefs.SetFloat("y", Player.position.y); //saves y position to registry labeled 'y'
        PlayerPrefs.SetFloat("z", Player.position.z); //saves z position to registry labeled 'z'
        PlayerPrefs.SetFloat("Cam_y", Player.eulerAngles.y); //uses vector3 scale to store rotation
        PlayerPrefs.SetString("Scene", scene.name);
        if (Quit)//if save and exit
        {
            Time.timeScale = 1;//let time flow normally
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive); //load main menu
        }
    }


    
	
}
