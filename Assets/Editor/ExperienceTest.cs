using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ExperienceTest {

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator ExperienceGainTest() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		var player = new GameObject();
		player.gameObject.AddComponent<Experience>();
		player.gameObject.AddComponent<CharacterStat>();
		int originalXP = player.GetComponent<Experience>().GetCurrentXP();

		player.GetComponent<Experience>().AddXP (50);
		int newXP= player.GetComponent<Experience>().GetCurrentXP();

		yield return null;

		Assert.AreNotEqual(originalXP, newXP);
		Assert.AreEqual(newXP, 50);
	}

	[UnityTest]
	public IEnumerator LevelUpTest()
	{
		// Use the Assert class to test conditions.
		// yield to skip a frame
		var player = new GameObject();
		player.gameObject.AddComponent<Experience>();
		player.gameObject.AddComponent<CharacterStat>();
		int originalLevel = player.GetComponent<Experience>().GetLevel();

		player.GetComponent<Experience>().AddXP (100);
		int newLevel= player.GetComponent<Experience>().GetLevel();

		yield return null;

		Assert.AreNotEqual(originalLevel, newLevel);
		Assert.AreEqual(newLevel, 2);
	}
}