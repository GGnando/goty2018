using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour {
    public Transform Player;
    
    void Awake()
    {
        Player.position = new Vector3 (PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z")); //Upon restart load game
        Player.eulerAngles = new Vector3(0, PlayerPrefs.GetFloat("Cam_y"));
    }

    public void SaveGameSettings(bool Quit)
    {
        PlayerPrefs.SetFloat("x", Player.position.x); //saves x position to registry labeled 'x'
        PlayerPrefs.SetFloat("y", Player.position.y); //saves y position to registry labeled 'y'
        PlayerPrefs.SetFloat("z", Player.position.z); //saves z position to registry labeled 'z'
        PlayerPrefs.SetFloat("Cam_y", Player.eulerAngles.y); //uses vector3 scale to store rotation
        if (Quit)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("simple_test");
        }
    }
	
}
