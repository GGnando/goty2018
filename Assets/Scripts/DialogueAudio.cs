using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAudio : MonoBehaviour {
    public AudioClip pushButton;
    public AudioSource buttonSource;

	// Use this for initialization
	void Start () {
        buttonSource.clip = pushButton;
	}

    // Update is called once per frame
    public void buttonNoise()
    {
        buttonSource.Play();
    }
}
