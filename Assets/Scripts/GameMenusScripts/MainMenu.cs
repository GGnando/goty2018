using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public Transform Player;

	public void PlayGame ()
	{
        SceneManager.LoadScene ("StartArea");
	}

    public void LoadGame ()
    {
        /*Player.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z")); //Upon restart load game
        Player.eulerAngles = new Vector3(0, PlayerPrefs.GetFloat("Cam_y"));   */     
        SceneManager.LoadScene("StartArea");
    }

	public void QuitGame ()
	{
		Debug.Log ("Quit has been pressed");
		Application.Quit ();
	}
}
