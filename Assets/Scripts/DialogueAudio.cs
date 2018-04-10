using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAudio : MonoBehaviour {
    public AudioClip pushButton;
    public AudioClip MusicClip;
    public AudioClip MusicClip2;
    public AudioClip GolbinLaugh;
    public AudioClip Swing;
    public AudioSource MusicSource;
    public AudioSource MusicSource2;
    public AudioSource buttonSource;
    public AudioSource GoblinLaughSource;
    public AudioSource SwingSource;

	// Use this for initialization
	void Start () {
        buttonSource.clip = pushButton;
        MusicSource.clip = MusicClip;
        MusicSource2.clip = MusicClip2;
        GoblinLaughSource.clip = GolbinLaugh;
        SwingSource.clip = Swing;
	}

    // Update is called once per frame
    public void buttonNoise()
    {
        buttonSource.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MusicSource.Play();
            MusicSource2.Play();
        }
    }

    public void GoblinSwing()
    {
        SwingSource.Play();
    }

    public void GoblinLaugh()
    {
        int randomNumber = Random.Range(1, 100);
        if (randomNumber < 10)
        {
            GoblinLaughSource.Play();
        }
    }
}
