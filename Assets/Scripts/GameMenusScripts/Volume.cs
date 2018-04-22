using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Volume : MonoBehaviour {

    public Slider volume;
    public AudioListener source;
	
	// Update is called once per frame
	void Update () {
		
	}
    public void AdjustVolume (float newValue)
    {
        AudioListener.volume = newValue;
    }
}
