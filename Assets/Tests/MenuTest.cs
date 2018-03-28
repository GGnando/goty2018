using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using NUnit.Framework;
using System.Collections;

public class PauseTest {
    public Transform Canvas;
    public Transform Player;

	[UnityTest]
	public IEnumerator Pauses() {
        var pause = new GameObject().AddComponent<PauseGame>();
        pause.pauseGame(); //Initiate Pause
        Assert.AreEqual(Time.timeScale, 0); //Does it pause the game?
        pause.unpauseGame();//Initiate Resume
        yield return new WaitForFixedUpdate();
        Assert.AreEqual(Time.timeScale, 1); //Does it unpause the game?
    }
    [UnityTest]
    public IEnumerator DisplaysMenu()
    {
        var canvas = new GameObject().AddComponent<Canvas>();
        canvas.gameObject.SetActive(false);
        Assert.IsFalse(canvas.gameObject.activeInHierarchy); //Does the Menu pop up?
        yield return null;
    }


    [UnityTest]
    public IEnumerator HidesMenu()
    {
        var canvas = new GameObject().AddComponent<Canvas>();
        canvas.gameObject.SetActive(true);
        Assert.IsTrue(canvas.gameObject.activeInHierarchy); //Does the Menu pop down?
        yield return null;
    }    
    /*[UnityTest]
    public IEnumerator SavesLocation()
    {
        var savegame = new GameObject().AddComponent<SaveGame>();
        //Player starts at null position and must be given coordinates
        //Player.position.Set(30, 40, 50);
        savegame.SaveGameSettings(false);
        Assert.AreEqual(30, PlayerPrefs.GetFloat("x", Player.position.x));
        Assert.AreEqual(40, PlayerPrefs.GetFloat("y", Player.position.y));
        Assert.AreEqual(50, PlayerPrefs.GetFloat("z", Player.position.z));
        yield return null;
    }*/
    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
}
