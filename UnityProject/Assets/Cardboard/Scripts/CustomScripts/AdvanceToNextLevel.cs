using UnityEngine;
using System.Collections;

public class AdvanceToNextLevel : MonoBehaviour {

	public void NextLevel()
	{
		if (Application.levelCount == (Application.loadedLevel + 1)) {
			Application.LoadLevel ("Hub");
		} else {
			Application.LoadLevel (Application.loadedLevel + 1);
		}
	}

	public void MainMenu()
	{
		Application.LoadLevel ("Hub");
	}
}
