using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFix : MonoBehaviour {
    public AudioClip sound;
    public AudioSource soundSource;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playSound()
    {
        soundSource.clip = sound;
        soundSource.Play();
    }
}
